    public class ImageFilter : IImageFilter<string, string>
    {
        public string Input { get; private set; }
        public ImageFilter(string input)
        {
            Input = input;
        }
        public string Process()
        {
            return Input.ToUpper();
        }
    }
