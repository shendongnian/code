    using using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    [Serializable]
    class Example
    {
        private int i;
        private void Save(string fileToSave)
        {
            using(Stream writer = File.OpenWrite(fileToSave))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(writer, this);
            }
        }
        private void Load(string loadFromFile)
        {
            using (Stream reader = File.OpenRead(loadFromFile))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Example temp = (Example)bf.Deserialize(reader);
                //and here you can restore your class from loadFromFile
                this.i = temp.i;
            }
        }
    }
