    public class ResourceReader
    {
        // to read the file as a Stream
        public static Stream GetResourceStream(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
            return resourceStream;
        }
        
        // to save the resource to a file
        public static void CreateFileFromResource(string resourceName, string path)
        {
            Stream resourceStream = GetResourceStream(resourceName);
            if (resourceStream != null)
            {
                using (Stream input = resourceStream)
                {
                    using (Stream output = File.Create(path))
                    {
                        input.CopyTo(output);
                    }
                }
            }
        }
    }
