    [Serializable]
    public class MyClass
    {
        SerializableBitmapImageWrapper testImage;
        public string TestString { get; set; }
        public BitmapImage TestImage { get { return testImage; } set { testImage = value; } }
    }
    public static class GenericCopier
    {
        public static T DeepCopy<T>(T objectToCopy)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, objectToCopy);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
