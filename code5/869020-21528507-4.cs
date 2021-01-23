    //get distinct list of element name under <data>
    var columns = doc.Root.Elements("data").Elements().Select(o => o.Name.LocalName).Distinct().ToList();
    var output = "";
    //add header to 'output' : MEMBNO,BASIC,DOB,
    columns.ForEach(o => output += o + ",");
    foreach (var data in doc.Descendants("data"))
    {
    	var line = Environment.NewLine;
    	foreach (var column in columns)
    	{
    		var cellValue = string.Join("\v", data.Elements(column).Select(o => (string)o).ToArray());
    		if (!string.IsNullOrEmpty(cellValue)) cellValue = "\"" + cellValue + "\"";
    		line += cellValue + ",";
    	}
    	output += line;
    }
    Console.WriteLine(output);
