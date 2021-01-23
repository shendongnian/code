    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication8 {
    	class Program {
    		static void Main(string[] args) {
    			var s1 = "<House><address>21 My House</address><id>1</id><owner>Optimation</owner></House>";
    			var s2 = "<House xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MVCwithWebAPIApplication.Models\"><address>21 My House</address><id>1</id><owner>Optimation</owner></House>";
    			House house = (House)XmlDeserializeFromString(s2, typeof(House));
    			Console.WriteLine(house.ToString());
    			Console.Read();
    		}
    
    		public static Object XmlDeserializeFromString(string objectData, Type type) {
    			var serializer = new XmlSerializer(type);
    			object result;
    
    			using (TextReader reader = new StringReader(objectData)) {
    				result = serializer.Deserialize(reader);
    			}
    
    			return result;
    		}
    
    
    	}
    
        //this is the only change
    	[XmlRoot(Namespace="http://schemas.datacontract.org/2004/07/MVCwithWebAPIApplication.Models")]
    	public class House {
    		public String address { get; set; }
    		public String id { get; set; }
    		public String owner { get; set; }
    
    		public override string ToString() {
    			return String.Format("address: {0} id: {1} owner: {2}", address, id, owner);
    		}
    	}
    }
