    public class ResourceReader
    {
        private static void CopyStream(Stream input, Stream output)
        {       
            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
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
                        CopyStream(input, output);
                    }
                }
            }
        }
    }
