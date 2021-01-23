	// temp table
	var dataTable = new DataTable("Table 1");
	dataTable.Columns.Add("title", typeof(string));
	dataTable.Columns.Add("number", typeof(int));
	dataTable.Columns.Add("subnum1", typeof(int));
	dataTable.Columns.Add("subnum2", typeof(int));
	// add temp data
	Enumerable.Range(1, 100000).ToList().ForEach(e =>
	{
		dataTable.Rows.Add(new object[] { "A", 1, 2, 3 });
	});
	// "bulk update"!
	var sb = new StringBuilder();
	var xmlWriter = XmlWriter.Create(sb);
	dataTable.WriteXml(xmlWriter);
	var xml = XDocument.Parse(sb.ToString());
	// take column to change
	var elementsToChange = xml.Descendants("title").ToList();
	// the list is referenced to the XML, so the XML is changed too!
	elementsToChange.ForEach(e => e.Value = "Z");
	// clear current table
	dataTable.Clear();
	// write changed data back to table
	dataTable.ReadXml(xml.CreateReader());
