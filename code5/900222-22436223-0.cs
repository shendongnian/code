        using (MemoryStream ms = new MemoryStream())
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            
            using (var writer = XmlWriter.Create(ms, settings))
            {
                var serializer = new XmlSerializer(typeof(List<Movie>));
                serializer.Serialize(writer, tmpList);
            }
            ms.Position = 0;
            XDocument doc = XDocument.Load(new XmlTextReader(ms));
            doc.Root.Add(new XAttribute("customAttribute", "Yes"));
            doc.Save(filename);
        }
