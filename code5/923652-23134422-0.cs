    //loop through <ItemGroupData> to get both date and type value
    //from each iteration
    var items = from i in doc.Descendants(nsSys + "ItemGroupData")
    			select new
    			{
    				date = (string)i.Element(nsSys + "ItemData").Attribute("Value"),
    				type = (string)i.Element(nsSys + "ItemData").Skip(1).First().Attribute("Value")
    			};
    DataTable modDt = new DataTable();
    modDt.Columns.Add(new DataColumn("Date", typeof(string)));
    modDt.Columns.Add(new DataColumn("Type", typeof(int)));
    
    //add LINQ-to-XML query result to DataTable
    foreach (var item in items)
    {
    	//convert item.date string to DateTime  
    	//then convert it back to string with different format
    	modDt.Rows.Add(DateTime.ParseExact(item.date, "yyyy-MM-dd", CultureInfo.InvariantCulture)
    						   .ToString("MM/dd/yyyy"), 
    				    int.Parse(item.type);
    }
