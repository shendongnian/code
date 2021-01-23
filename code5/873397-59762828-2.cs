    public class EmbededResourceReader
    {
        protected string LoadString(string fileName)
        {
            return LoadString(fileName, Encoding.UTF8);
        }
        protected string LoadString(string fileName, Encoding encoding)
        {
            var assembly = this.GetType().Assembly;
            var resourceStream = assembly.GetManifestResourceStream($"{this.GetType().Namespace}.{fileName}");
            using (var reader = new StreamReader(resourceStream, encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
