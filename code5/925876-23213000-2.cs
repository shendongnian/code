    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    public class Config
    {
        public string appname;
    }
    
    public class CustomConfig1 : Config
    {
        public string CustomConfig1Param1;
        public string CustomConfig1Param2;
    }
    
    public class CustomConfig2 : Config
    {
        public string CustomConfig2Param1;
        public string CustomConfig2Param2;
    }
    
    static class Program
    {
        static void Main()
        {
            var original = new CustomConfig1
            {
                appname = "foo",
                CustomConfig1Param1 = "x",
                CustomConfig1Param2 = "y"
            };
            var xml = Serialize(original);
            var clone = DeserializeConfig(xml);
            Console.WriteLine(clone.appname);
            var typed = (CustomConfig1)clone;
            Console.WriteLine(typed.CustomConfig1Param1);
            Console.WriteLine(typed.CustomConfig1Param2);
        }
        public static string Serialize(Config obj)
        {
            using (var serialized = new StringWriter())
            {
                GetConfigSerializer().Serialize(serialized, obj);
                return serialized.ToString();
            }
        }
        public static Config DeserializeConfig(string xml)
        {
            using(var reader = new StringReader(xml))
            {
                return (Config)GetConfigSerializer().Deserialize(reader);
            }
        }
        static Type[] GetKnownTypes()
        {
            // TODO: resolve types properly
            return new[] { typeof(CustomConfig1), typeof(CustomConfig2) };
        }
        private static XmlSerializer configSerializer;
        public static XmlSerializer GetConfigSerializer()
        {
            return configSerializer ?? (configSerializer =
                new XmlSerializer(typeof(Config), GetKnownTypes()));
        }
    }
