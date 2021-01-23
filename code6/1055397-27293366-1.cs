    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class Program {
    	static void Main() {
			List<string> Data=new List<string> { "A","B","C","D","E" };
	
			XmlSerializer XMLs=new XmlSerializer(Data.GetType());
			XMLs.Serialize(Console.Out,Data);
	
			Console.ReadKey(true);
		}
	}
