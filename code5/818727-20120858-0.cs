    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication5 {
    	class Program {
    		static void Main(string[] args) {
    			var xml1 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <entity tag=\"gentype\" value=\"java\" />";
    			var xml2 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <entity tag=\"gentype\" value=\"c#\" />";
    
    			var entity1 = DeserializeFrom(xml1);
    			var entity2 = DeserializeFrom(xml2);
    
    			if (entity1 != entity2) {
    				entity1.Status = "changed";
    			}
    
    			var newxml = SerializeTo(entity1);
    			Console.WriteLine(newxml);
    			Console.Read();
    		}
    
    		static Entity DeserializeFrom(String xmlText) {
    			var bytes = Encoding.UTF8.GetBytes(xmlText);
    			using (var stream = new MemoryStream(bytes)) {
    				var serializer = new XmlSerializer(typeof(Entity));
    				return (Entity)serializer.Deserialize(stream);
    			}
    		}
    
    		static String SerializeTo(Entity entity) {
    			var bytes = new byte[1024];
    			using (var stream = new MemoryStream(bytes)) {
    				var serializer = new XmlSerializer(typeof(Entity));
    				serializer.Serialize(stream, entity);
    			}
    			return Encoding.UTF8.GetString(bytes);
    		}
    
    
    	}
    
    	[XmlRoot("entity")]
    	public class Entity {
    		[XmlAttribute("tag")]
    		public String Tag { get; set; }
    
    		[XmlAttribute("value")]
    		public String Value { get; set; }
    
    		[XmlAttribute("status")]
    		public String Status { get; set; }
    
    		public override bool Equals(object obj) {
    			var entity = (Entity)obj;
    			return this.Tag == entity.Tag && this.Value == entity.Value;
    		}
    	}
    } 
