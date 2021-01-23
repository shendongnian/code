        public static bool Save(Animal animal)
        {
            var lListOfAnimals = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                             from lType in lAssembly.GetTypes()
                             where typeof(Animal).IsAssignableFrom(lType)
                             select lType).ToArray();
            System.Xml.Serialization.XmlSerializer ListSer = new System.Xml.Serialization.XmlSerializer(typeof(Animal), lListOfAnimals);
