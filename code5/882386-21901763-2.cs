    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    public class SomeType
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }
    public class MyTest
    {
        public static SomeType[] Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SomeType[]));
            StringReader stringReader = new StringReader(xml);
            SomeType[] types = (SomeType[])serializer.Deserialize(stringReader);
            stringReader.Close();
            return types;
        }
        public static void Main()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <ArrayOfSomeType>
       <SomeType>
          <Field1>val</Field1>
          <Field2>val</Field2>
          <Field3>val</Field3>
       </SomeType>
    </ArrayOfSomeType>";
            var items = Deserialize(xml);
            foreach (var item in items)
            {
                Console.WriteLine("{0}, {1}, {2}",
                    item.Field1, item.Field2, item.Field3);
            }
        }
    }
