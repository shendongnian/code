        public static void SerializeObject(string filename, Object objectToSerialize)
        {
            using (var stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, objectToSerialize);
            }
        }
