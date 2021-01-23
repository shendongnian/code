        public static List<CatPict> feed()
        {
            CatPict tempcat = new CatPict();
            string xml = XDocument.Load("XMLFile1.xml").ToString();
            using (XmlReader reader = new XmlTextReader(new StringReader(xml)))
            {
                while (reader.Read())
                {
                    //put your logic here
                }
            }
            return Listpict;
        }
