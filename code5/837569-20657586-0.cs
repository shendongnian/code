    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication8 {
    	class Program {
    		static void Main(string[] args) {
    			Room r = new Room();
    			r.Persons = new List<Person>();
    			r.Persons.Add(new Student() { StudentID = "001" });
    			r.Persons.Add(new Teacher() { Name = "James" });
    			
    			var serializer = new XmlSerializer(typeof(Room));
    			serializer.Serialize(Console.Out, r);
    			
    			Console.Read();
    		}
    	}
    
    	public class Person { }
    
    	public class Student : Person {
    		public String StudentID { get; set; }
    	}
    
    	public class Teacher : Person {
    		public String Name { get; set; }
    	}
    
    	public class Room {
    		[XmlArrayItem(typeof(Student)),
    		XmlArrayItem(typeof(Teacher))]
    		public List<Person> Persons { get; set; }
    	}
    }
