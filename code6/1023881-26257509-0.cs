    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace X123
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                MeterWalkOrder mo = new MeterWalkOrder();
                mo.Name = "name";
                mo.Meters.Add(new Meter { MeterID = 1, SerialNumber = "kdkdkd" });
                mo.Meters.Add(new Meter { MeterID = 2, SerialNumber = "holladrio" });
    
                var xmlSerializer = new XmlSerializer(typeof(MeterWalkOrder), new Type[] { typeof(Meter) });
                {
                    xmlSerializer.Serialize(File.CreateText("hello.xml"), mo);
                    using (Stream s = File.OpenRead("hello.xml"))
                    {
                        var obj = xmlSerializer.Deserialize(s);
                    }
                }
            }
    
    
    
        }
    
        [Serializable]
        public class MeterWalkOrder
        {
            public MeterWalkOrder()
            {
            }
    
            public string Name { get; set; }
            public List<Meter> Meters { get { return meters; } set { meters = value; } }
            private List<Meter> meters = new List<Meter>();
        }
    
        [Serializable]
        public class Meter
        {
            public Meter()
            {
            }
    
            [XmlAttribute]
            public int MeterID { get; set; }
    
            [XmlAttribute]
            public string SerialNumber { get; set; }
        }
