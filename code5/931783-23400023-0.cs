    public class DecoderTests
    {
        public String OneItem { get; set; }
        public String SecondItem { get; set; }
        public String ThirdClean { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ddd = Uri.EscapeUriString("Http://google tes.com");
            var decod = new DecoderTests
            {
                OneItem = ddd.ToString(),
                SecondItem = ddd.ToString(),
                ThirdClean = "clean"
            };
            PropertyInfo[] properties = typeof(DecoderTests).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var current = property.GetValue(decod) as String;
                if (!String.IsNullOrEmpty(current))
                {
                    property.SetValue(decod, Uri.UnescapeDataString(current));
                }
            }
        }
    }
