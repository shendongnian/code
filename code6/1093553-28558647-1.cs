        public static void WriteResourceToFile(string name, string destination)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            if (stream == null)
            {
                throw new ArgumentException(string.Format("Resource '{0}' not found", name), "name");
            }
            using (var fs = new FileStream(destination, FileMode.Create))
            {
                stream.CopyTo(fs);
            }
        }
