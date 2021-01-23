    [Serializable]
    public class MyClass
    {
        BitmapImage testImage;
        public string TestString { get; set; }
        public BitmapImage TestImage { get { return testImage; } set { testImage = value; } }
    }
