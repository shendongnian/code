    using System;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml.Linq;
    using System.Diagnostics;
    
    namespace Sample_04_03_2014_01
    {
        public class Sample
        {
            public string Name { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Sample s = new Sample();
                s.Name = "Hello";
                var serializer = new XmlSerializer(typeof(Sample));
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    serializer.Serialize(sw, s);
                }
                string serialized = sb.ToString();
                Console.WriteLine(serialized);
    
                var root = XDocument.Parse(serialized).Root;
                Sample someType1 = null;
                Stopwatch stopWatch1 = new Stopwatch();
                stopWatch1.Start();
                for (int i = 0; i < 100000; i++)
                {
                    var serializer1 = new XmlSerializer(typeof(Sample));
                    using (var reader = root.CreateReader())
                    {
                        someType1 = (Sample)serializer1.Deserialize(reader);
                    }
                }
                stopWatch1.Stop();
                Console.WriteLine(someType1.Name);
                Console.WriteLine(stopWatch1.Elapsed);
    
                Sample someType2 = null;
                Stopwatch stopWatch2 = new Stopwatch();
                stopWatch2.Start();
                for (int i = 0; i < 100000; i++)
                {
                    var serializer2 = new XmlSerializer(typeof(Sample));
                    using (TextReader reader = new StringReader(serialized))
                    {
                        someType2 = (Sample)serializer2.Deserialize(reader);
                    }
                }
                stopWatch2.Stop();
                Console.WriteLine(someType2.Name);
                Console.WriteLine(stopWatch2.Elapsed);
            }
        }
    }
