        static void Main(string[] args)
        {
            const string folder = "C:\\";
            // Loop trough all
            foreach (var file in Directory.EnumerateFiles(folder, "*.xml"))
            {
                var document = XDocument.Load(file);
            }
            // When it should explicitly be one
            var singleFile = Directory.GetFiles(folder, "*.xml").SingleOrDefault();
            var document = XDocument.Load(singleFile);
        }
