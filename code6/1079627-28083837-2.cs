    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;
    [Serializable]
    public class JsonData {
        [XmlElement("labels")]
        public List<JsonLabel> labels { get; set; }
        [XmlElement("0")]
        public int zero { get; set; }
        [XmlElement("error")]
        public bool error { get; set; }
        [XmlElement("status")]
        public int status { get; set; }
    }
    [Serializable]
    public class JsonLabel {
        [XmlElement("id")]
        public int id { get; set; }
        [XmlElement("descrizione")]
        public string descrizione { get; set; }
        [XmlElement("tipo")]
        public int tipo { get; set; }
        [XmlElement("template_file")]
        public string template_file { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            string json = @"your json string here...";
            var jsonData = new JavaScriptSerializer().Deserialize<JsonData>(json);
            foreach (var label in jsonData.labels) {
                Console.WriteLine(label.id);
            }
        }
    }
