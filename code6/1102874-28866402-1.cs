    class ObjectA : IObj
    {
        public string Read()
        {
            var xDoc = XDocument.Load(xmlPath);
        
            foreach (var read in xDoc.Descendants("Read"))
            {
                var resultid = int.Parse(read.Attribute("resultid").Value);
                var locationid = int.Parse(read.Attribute("locationid").Value);
                Read(resultid, locationid);
            }
            
            return something;
        }
    }
