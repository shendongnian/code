    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [XmlIgnore]
        public BitmapSource Image { get; set; }
        private byte[] imageBuffer;
        public byte[] ImageBuffer
        {
            get
            {
                if (imageBuffer == null && Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var encoder = new JpegBitmapEncoder(); // or other encoder
                        encoder.Frames.Add(BitmapFrame.Create(Image));
                        encoder.Save(stream);
                        imageBuffer = stream.ToArray();
                    }
                }
                return imageBuffer;
            }
            set
            {
                imageBuffer = value;
                using (var stream = new MemoryStream(imageBuffer))
                {
                    var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    Image = decoder.Frames[0];
                }
            }
        }
    }
