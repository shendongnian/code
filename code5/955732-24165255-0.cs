    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    
    namespace CommandLineProgram.Miscellaneous
    {
        public class SerializeSerClass
        {
            public static void Main()
            {
                XmlSerializer ser = new XmlSerializer(typeof(SerClass));
                using (StringWriter writer = new StringWriter())
                {
                    ser.Serialize(writer, new SerClass());
                    Console.WriteLine(writer.ToString());
                }
            }
        }
    
        [Serializable]
        public class Line
        {
            public string Name { get; set; }
            public Line()
            {
                Name = "Line";
            }
        }
        [Serializable]
        public class Circle
        {
            public string Name { get; set; }
            public Circle()
            {
                Name = "Circle";
            }
        }
        [Serializable]
        public class Square
        {
            public string Name { get; set; }
            public Square()
            {
                Name = "Square";
            }
        }
    
        [Serializable]
        public class SerClass
        {
            public GeometryCollection[] GeoCollection { get; set; }
            public SerClass()
            {
                GeoCollection = new GeometryCollection[] 
                { 
                    new GeometryCollection() 
                    { 
                        Circle = new Circle(), 
                        Square = new Square(), 
                        Line = new Line() 
                    },
                    new GeometryCollection() 
                    { 
                        Circle = new Circle(), 
                        Square = new Square(), 
                        Line = new Line() 
                    },
                    new GeometryCollection() 
                    { 
                        Circle = new Circle(), 
                        Square = new Square(), 
                        Line = new Line() 
                    } 
                };
            }
        }
    
        [Serializable]
        public class GeometryCollection
        {
            public Line Line { get; set; }
            public Square Square { get; set; }
            public Circle Circle { get; set; }
        }
    }
    
    
