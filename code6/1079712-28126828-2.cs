    using System;
    using System.Xml.Serialization;
    namespace XmlTest
    {
        public abstract class RootElement
        {
        }
        public class TypeA : RootElement
        {
            public string AData
            {
                get;
                set;
            }
        }
        public class TypeB : RootElement
        {
            public int BData
            {
                get;
                set;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(RootElement),
                    new Type[]
                    {
                        typeof(TypeA),
                        typeof(TypeB)
                    });
                RootElement rootElement = null;
                string axml = "<RootElement xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:type=\"TypeA\"><AData>Hello A</AData></RootElement>";
                string bxml = "<RootElement xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:type=\"TypeB\"><BData>1234</BData></RootElement>";
                foreach (var s in new string[] { axml, bxml })
                {
                    using (var reader = new System.IO.StringReader(s))
                    {
                        rootElement = (RootElement)serializer.Deserialize(reader);
                    }
                    TypeA a = rootElement as TypeA;
                    if (a != null)
                    {
                        Console.WriteLine("TypeA: {0}", a.AData);
                    }
                    else
                    {
                        TypeB b = rootElement as TypeB;
                        if (b != null)
                        {
                            Console.WriteLine("TypeB: {0}", b.BData);
                        }
                        else
                        {
                            Console.Error.WriteLine("Unexpected type.");
                        }
                    }
                }
            }
        }
    }
