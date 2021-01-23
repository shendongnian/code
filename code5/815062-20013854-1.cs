    public static class MyStaticClass
    {
        //this is where we store the xml file line after line
        private static List<string> _xmlLines;
        
        //this is the class' static constructor
        //this code will be the first to run (you do not have to call it, it's automated)
        static MyStaticClass()
        {
            _xmlLines = new List<string>();
            using (System.IO.StreamReader xml = new System.IO.StreamReader("yourFile.xml"))
                {
                    string line = null;
                    while ((line = xml.ReadLine()) != null)
                    {
                        _xmlLines.Add(line);
                    }
                }
                //remember to catch your exceptions here
        }
        //this is the get-only auto property
        public static List<string> XmlLines
        {
            get
            {
                return _xmlLines;
            }
        }
    }
