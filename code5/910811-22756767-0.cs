    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    namespace ConsoleApp1
    {
        namespace Test1
        {
            [DataContract(Namespace="")]
            public sealed class Demo
            {
                [DataMember]
                public string Value { get; set; }
            }
        }
        namespace Test2
        {
            [DataContract(Namespace="")]
            public sealed class Demo
            {
                [DataMember]
                public string Value { get; set; }
            }
        }
        sealed class Program
        {
            private void run()
            {
                string filename = Path.GetTempFileName();
                var demo1 = new Test1.Demo {Value = "DEMO"};
                ToFile(filename, demo1);
                var demo2 = FromFile<Test2.Demo>(filename);
                Console.WriteLine(demo2.Value);
            }
            public static void ToFile(string filename, object obj)
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                using (var streamWriter = File.CreateText(filename))
                using (var xmlWriter    = XmlWriter.Create(streamWriter, new XmlWriterSettings{Indent = true}))
                {
                    serializer.WriteObject(xmlWriter, obj);
                }
            }
            public static T FromFile<T>(string filename)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                using (var textReader = File.OpenText(filename))
                using (var xmlReader  = XmlReader.Create(textReader))
                {
                    return (T)serializer.ReadObject(xmlReader);
                }
            }
            [STAThread]
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
