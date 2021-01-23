    public static class File
    {
        public static String ReadAllText(String path)
        {
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
    }
