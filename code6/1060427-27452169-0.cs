    public class JavaScriptImageConverter : JavaScriptConverter
    {
        readonly List<Type> Types = new List<Type>();
        const string base64key = "Base64Image";
        public JavaScriptImageConverter() : base()
        {
            Types.Add(typeof(Bitmap)); // Add additional types if required?
            Types.Add(typeof(Image));
        }
        static string ToBase64String(System.Drawing.Image imageIn)
        {
            if (imageIn == null)
                return null;
            ImageConverter converter = new ImageConverter();
            return Convert.ToBase64String((byte[])converter.ConvertTo(imageIn, typeof(byte[])));
        }
        public static Image FromBase64String(string imageString)
        {
            if (string.IsNullOrEmpty(imageString))
                return null;
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(Convert.FromBase64String(imageString));
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (!typeof(Image).IsAssignableFrom(type))
                return null;
            object obj;
            if (!dictionary.TryGetValue(base64key, out obj))
                return null;
            var str = obj as string;
            if (str == null)
                return null;
            return FromBase64String(str);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var image = (Image)obj;
            var serialized = new Dictionary<string, object>();
            serialized[base64key] = ToBase64String(image);
            return serialized;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get {
                return Types;
            }
        }
    }
