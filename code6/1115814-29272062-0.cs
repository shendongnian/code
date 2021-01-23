    public static class SimpleClass
    {
        const string resourceName = "MyNameSpace.data.xml";
        static XmlDocument _myXmlDocu = null;
        static SimpleClass()
        {
            _myXmlDocu = new XmlDocument();
            Assembly asm = Assembly.GetExecutingAssembly();
            using (var reader = new XmlTextReader(asm.GetManifestResourceStream(resourceName)))
            {
                _myXmlDocu.Load(reader);
            }
        }
        public static XmlDocument GetResourceData()
        {
            return _myXmlDocu;
        }
    }
