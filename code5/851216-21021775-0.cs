    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    namespace Demo
    {
        [DataContract(Namespace = "")]
        public class User
        {
            [DataMember]
            public virtual string Name
            {
                get;
                set;
            }
            [DataMember]
            public virtual DateTime? LastUpdated
            {
                get;
                set;
            }
            [DataMember]
            public virtual int? ContactId
            {
                get;
                set;
            }
            [DataMember]
            public virtual IList<string> Sectors
            {
                get;
                set;
            }
        }
        internal class Program
        {
            private void run()
            {
                User user = new User();
                user.Sectors = new[] {"One", "Two", "Three"};
                user.Name = "Test Name";
                // Serialize
                var result = new StringBuilder();
                DataContractSerializer serializer = new DataContractSerializer(user.GetType());
                using (var stringWriter = new StringWriter(result))
                using (var xmlWriter    = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true } ))
                {
                    serializer.WriteObject(xmlWriter, user);
                }
                string serialisedToString = result.ToString();
                Console.WriteLine(serialisedToString);
                // Deserialize
                using (var stringReader = new StringReader(serialisedToString))
                using (var xmlReader    = XmlReader.Create(stringReader))
                {
                    user = (User) serializer.ReadObject(xmlReader);
                }
                Console.WriteLine(user.Name);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
