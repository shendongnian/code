    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		string pattern = @"(?>[^""';]+|""(?>[^""]+|"""")*""|'(?>[^']+|'')*')+";
            string input = @"show tables;
                             insert into table_x values (""string;s"",""id_s"",1);
                             insert into table2_x values (""s;s"",1);
                             insert into table2_x values ('s'';s',1);";
    
        	List<string> list = new List<string>();
          
        	foreach (Match m in Regex.Matches(input, pattern)) {
                list.Add(m.Value.Trim());
          	}
          	string[] commands = list.ToArray();
          
          	foreach (string s in commands) {
          		Console.WriteLine(s);
          	}
    	}
    }
