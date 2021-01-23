	public static bool FilterField(this ExcelPivotTable pivotTable, string pageFieldName, IEnumerable<object> filters, ExcelWorksheet dataWorksheet = null)
	{
		//set the worksheet
		var ws = dataWorksheet ?? pivotTable.WorkSheet;
		//Set the cache definitions and cache fields
		var xdCacheDefinition = pivotTable.CacheDefinition.CacheDefinitionXml;
		var xeCacheFields = xdCacheDefinition.FirstChild["cacheFields"];
		if (xeCacheFields == null)
			return false;
		//Go the field list in the definitions, note the field idx and valuesfor 
		var count = 0;
		var fieldIndex = -1;
		List<object> fieldValues = null;
		foreach (XmlElement cField in xeCacheFields)
		{
			var att = cField.Attributes["name"];
			if (att != null && att.Value.Equals(pageFieldName, StringComparison.OrdinalIgnoreCase))
			{
				//store the field data
				fieldIndex = count;
				var dataddress = new ExcelAddress(pivotTable.CacheDefinition.SourceRange.Address);
				var valueHeader = ws
					.Cells[dataddress.Start.Row, dataddress.Start.Column, dataddress.Start.Row, dataddress.End.Column]
					.FirstOrDefault(cell => cell.Value.ToString().Equals(pageFieldName, StringComparison.OrdinalIgnoreCase));
				if (valueHeader == null)
					return false;
				//Get the range minus the header row
				var valueObject = valueHeader.Offset(1, 0, dataddress.End.Row - dataddress.Start.Row, 1).Value;
				var values = (object[,])valueObject;
				fieldValues = values
					.Cast<object>()
					.Distinct()
					.ToList();
				//fill in the shared items for the field
				var sharedItems = cField.GetElementsByTagName("sharedItems")[0] as XmlElement;
				if (sharedItems == null)
					continue;
				//set the collection attributes
				sharedItems.RemoveAllAttributes();
				att = xdCacheDefinition.CreateAttribute("count");
				att.Value = fieldValues.Count.ToString(CultureInfo.InvariantCulture);
				sharedItems.Attributes.Append(att);
				//create and add the item
				foreach (var fieldvalue in fieldValues)
				{
					var item = xdCacheDefinition.CreateElement("s", sharedItems.NamespaceURI);
					att = xdCacheDefinition.CreateAttribute("v");
					att.Value = fieldvalue.ToString();
					item.Attributes.Append(att);
					sharedItems.AppendChild(item);
				}
				break;
			}
			count++;
		}
		if (fieldIndex == -1 || fieldValues == null)
			return false;
		//Now go back to the main pivot table xml and add the cross references to complete filtering
		var xdPivotTable = pivotTable.PivotTableXml;
		var xdPivotFields = xdPivotTable.FirstChild["pivotFields"];
		if (xdPivotFields == null)
			return false;
		var filtervalues = filters.ToList();
		count = 0;
		foreach (XmlElement pField in xdPivotFields)
		{
			//Find the asset type field
			if (count == fieldIndex)
			{
				var att = xdPivotTable.CreateAttribute("multipleItemSelectionAllowed");
				att.Value = "1";
				pField.Attributes.Append(att);
				var items = pField.GetElementsByTagName("items")[0] as XmlElement;
				if (items == null)
					return false;
				items.RemoveAll();
				att = xdPivotTable.CreateAttribute("count");
				att.Value = (fieldValues.Count + 1).ToString(CultureInfo.InvariantCulture);
				items.Attributes.Append(att);
				pField.AppendChild(items);
				//Add the classes to the fields item collection
				for (var i = 0; i < fieldValues.Count; i++)
				{
					var item = xdPivotTable.CreateElement("item", items.NamespaceURI);
					att = xdPivotTable.CreateAttribute("x");
					att.Value = i.ToString(CultureInfo.InvariantCulture);
					item.Attributes.Append(att);
					if (filtervalues.Contains(fieldValues[i]))
					{
						att = xdPivotTable.CreateAttribute("h");
						att.Value = "1";
						item.Attributes.Append(att);
					}
					items.AppendChild(item);
				}
				//Add the default
				var defaultitem = xdPivotTable.CreateElement("item", items.NamespaceURI);
				att = xdPivotTable.CreateAttribute("t");
				att.Value = "default";
				defaultitem.Attributes.Append(att);
				items.AppendChild(defaultitem);
				break;
			}
			count++;
		}
		return true;
	}
