     public void saveXML(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer format = new XmlSerializer(typeof(List<MyClass>));
                format.Serialize(stream, this.postList);
            }
        }
        private void readXML(string fileLocation)
        {
            using (FileStream stream = new FileStream(fileLocation,FileMode.Open))
            {
                XmlSerializer format = new XmlSerializer(typeof(List<MyClass>));
                postList = format.Deserialize(stream) as List<MyClass>;
              
            }
        }
