    public class SerializeManagement<T>
    {
        public static T ReadFromXML(string iPath)
         {
            T val = default(T);
            try
            {
                // load from XML
                using (var sw = new StreamReader(iPath, Encoding.Default))
                {
                    var ser = new XmlSerializer(typeof(T));
                    val = (T)ser.Deserialize(sw);
                }
            }
            catch
            {
                Console.WriteLine("Problem reading from xml data file.");
            }
            return val;
        }
        public void SaveToXML(string iPath)
        {
            try
            {
                //TODO => using
                var sw = new StreamWriter(iPath, false, Encoding.Default);
                var ser = new XmlSerializer(typeof(T));
                ser.Serialize(sw, this);
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Problem saving to xml data file.");
            }
        }
    }
