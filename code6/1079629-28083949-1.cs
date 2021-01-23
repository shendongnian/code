        [TestMethod]
        public void test()
        {
            string json = "{\"labels\" : [{\"id\" : \"1\",\"descrizione\" : \"Etichetta interna\",\"tipo\" : \"0\",\"template_file\" : \"et_int.txt\"}, {\"id\" : \"2\",\"descrizione\" : \"Etichetta esterna\",\"tipo\" : \"1\",\"template_file\" : \"et_ext.txt\"}],\"0\" : 200,\"error\" : false,\"status\" : 200}";
            var root = JsonConvert.DeserializeObject<Rootobject>(json);
            foreach (var label in root.Labels)
            {
                //Use label.Id, label.Descrizione, label.Tipo, label.TemplateFile
            }
        }
        public class Rootobject
        {
            public Label[] Labels { get; set; }
            public int _0 { get; set; }
            public bool Error { get; set; }
            public int Status { get; set; }
        }
        public class Label
        {
            public string Id { get; set; }
            public string Descrizione { get; set; }
            public string Tipo { get; set; }
            public string TemplateFile { get; set; }
        }
