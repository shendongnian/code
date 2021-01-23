    public static class CloningExtention
    {
        public static T ShallowClone(this T obj) => (T)obj.MemberwiseClone(); // Doesn't work
        public static T DeepClone(this T obj)
        {
            BinaryFormatter BF = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            BF.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;
            return (T)BF.Deserialize(memStream);
        };
    }
