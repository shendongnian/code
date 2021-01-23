    var xml = @"<root>
    <data>
      <MEMBNO>11400116</MEMBNO> 
      <BASIC>15400.00</BASIC> 
      <BASIC>15000.00</BASIC> 
      <BASIC>14242.50</BASIC> 
    </data>
    <data>
       <MEMBNO>200</MEMBNO>
       <DOB>17/02/1975</DOB>
    </data>
    <data>
       <MEMBNO>16</MEMBNO>
       <BASIC>26354.00</BASIC>
    </data>
    </root>";
    var doc = XDocument.Parse(xml);
    var output = "";
    foreach(var data in doc.Descendants("data"))
    {
    	var membno = (string)data.Element("MEMBNO");
    	var basic = string.Join("\v", data.Elements("BASIC").Select(o => (string)o).ToArray());
    	if (!string.IsNullOrEmpty(basic)) basic = "\"" + basic + "\"";
    	var dob = (string)data.Element("DOB");
    	var line = string.Format("{0},{1},{2},", membno, basic, dob);
    	output += line + Environment.NewLine;
    }
    Console.WriteLine(output);
