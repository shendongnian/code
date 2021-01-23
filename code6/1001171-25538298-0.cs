    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    
	public static void WriteXlsOutput(Dictionary<string, IacTransmittal> collection) //accepting one dictionary as a parameter
	{
		using (FileStream outFile = new FileStream("Example.xlsx", FileMode.Create))
		{
			using (ExcelPackage ePackage = new ExcelPackage(outFile))
			{
				//group the collection by date property on your class
				foreach (IGrouping<DateTime, IacTransmittal> collectionByDate in collection
					.OrderBy(i => i.Value.Date.Date)
					.GroupBy(i => i.Value.Date.Date)) //assuming the property is named Date, using Date property of DateTIme so we only create new worksheets for individual days
				{
					ExcelWorksheet eWorksheet = ePackage.Workbook.Worksheets.Add(collectionByDate.Key.Date.ToString("yyyyMMdd")); //add a new worksheet for each unique day
					Type iacType = typeof(IacTransmittal);
					PropertyInfo[] iacProperties = iacType.GetProperties();
					int colCount = iacProperties.Count(); //number of properties determines how many columns we need
					//set column headers based on properties on your class
					for (int col = 0; col < colCount; col++)
					{
						eWorksheet.Cells[0, col].Value = iacProperties[col].Name ; //assign the value of the cell to the name of the property
					}
					int rowCounter = 2;
					foreach (IacTransmittal iacInfo in collectionByDate) //iterate over each instance of this class in this igrouping
					{
						int interiorColCount = 0;
						foreach (PropertyInfo iacProp in iacProperties) //iterate over properties on the class
						{
							eWorksheet.Cells[rowCounter, interiorColCount].Value = iacProp.GetValue(iacInfo, null); //assign cell values by getting the value of each property in the class
							interiorColCount++;
						}
						rowCounter++;
					}
				}
				ePackage.Save();
			}
		}
	}
