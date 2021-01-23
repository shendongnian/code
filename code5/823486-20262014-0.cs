    public class SaveItem
    {
        // ----------------------------------------------
        // version 1.02:
        public bool New { get; set; }
        public string VeryNew { get; set; }
        // ----------------------------------------------
        // version 1.01:
        public bool Bugfix { get; set; }
        public List<string> AList { get; set; } 
        public SaveItem()
        {
            // ...
        }
        public bool TrySave(string fullFilePath)
        {
            bool result = false;
            TextWriter textWriter = new StreamWriter(fullFilePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveItem));
            try
            {
                xmlSerializer.Serialize(textWriter, this);
                result = true;
            }
            catch (IOException)
            {
               
            }
            finally
            {
                try
                {
                    textWriter.Close();
                }
                catch
                { }
            }
            return result;
        }
        public static bool TryLoad(string fullFilePath, out SaveItem saveItem)
        {
            bool result = false;
            saveItem = new SaveItem();
            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(fullFilePath);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveItem));
                saveItem = (SaveItem)xmlSerializer.Deserialize(textReader);
                if (saveItem != null)
                {
                    result = true;
                }
            }
            catch (FileNotFoundException)
            {
                if (saveItem != null)
                {
                }
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
            return result;
        }
    }
