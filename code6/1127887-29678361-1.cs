    var xml = "<Form1><Name Key='4/13/2015 6:31:26 AM'><Date>4/13/2015</Date><JobNum>00000</JobNum><RevNum>00000</RevNum><Task>TimeStar</Task><Start>06:31 AM</Start><End>06:35 AM</End><TotalTime>2163346393</TotalTime></Name><Name Key='4/13/2015 6:35:11 AM'><Date>4/13/2015</Date><JobNum>27163</JobNum><RevNum>00000</RevNum><Task>Redlines</Task><Start>06:35 AM</Start><End>07:35 AM</End><TotalTime>36229156954</TotalTime></Name><Name Key='4/13/2015 6:35:11 AM'><Date>6/13/2015</Date><JobNum>27163</JobNum><RevNum>00000</RevNum><Task>Redlines</Task><Start>06:35 AM</Start><End>07:35 AM</End><TotalTime>36229156954</TotalTime></Name></Form1>";
    var document = XDocument.Parse(xml);
    
    foreach (var dates in document.Root.Elements("Name").GroupBy(i => i.Element("Date").Value))
    {
     	double summ = 0;
    	foreach (var date in dates)
    	{
    		summ += Convert.ToDouble(date.Element("TotalTime").Value);
    	}
    	
    	Console.WriteLine ("Date {0} = {1}", dates.Key, summ);
    }
