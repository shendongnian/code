    public static class serialize
    {
    public static T Deserialize<T>(string path)
            {
                T result;
                using (var stream = File.Open(path, FileMode.Open))
                {
                    result = Deserialize<T>(stream);
                }
                return result;
            }
    
    public static void Serialize<T>(T root, string path)
            {
                using (var stream = File.Open(path, FileMode.Create))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(stream, root);
                }
            }
    
    public static T Deserialize<T>(Stream stream)
            {
                
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stream);
            }
    }
