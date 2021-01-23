        public MemoryStream ApplyOpenXmlFix(MemoryStream input)
        {
            XNamespace contentTypesNamespace = "http://schemas.openxmlformats.org/package/2006/content-types";
            string filename = "[Content_Types].xml";
            input.Seek(0, SeekOrigin.Begin);
            ZipFile zipArchive = ZipFile.Read(input);
            ZipEntry file = zipArchive.Entries.Where(e => e.FileName == filename).Single();
            var xmlDocument = XDocument.Load(file.OpenReader());
            var newElement = new XElement(
                 contentTypesNamespace + "Override",
                new XAttribute("PartName", "/ppt/presentation.xml"),
                new XAttribute("ContentType", "application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml"));
            xmlDocument.Root.Add(newElement);
            MemoryStream updatedDocument = new MemoryStream();
            xmlDocument.Save(updatedDocument, SaveOptions.DisableFormatting);
            updatedDocument.Seek(0, SeekOrigin.Begin);
            zipArchive.UpdateEntry(filename, updatedDocument);
            MemoryStream output = new MemoryStream();
            zipArchive.Save(output);
            return output;
        }
