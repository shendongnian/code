    public class MetadataCreator
    {
        private XNamespace FileNamespace = "http://ns.exiftool.ca/File/1.0/";
        private XNamespace SystemNamespace = "http://ns.exiftool.ca/File/System/1.0/";
        private IMetadataBuilder builder;
        public Metadata Create(string destination, string fileName, string exifToolPath)
        {
            var fullPath = Path.Combine(destination, fileName);
            var document = new XDocument(GetFullXml(fullPath, exifToolPath));
            var fileSize = (string)document.Descendants(SystemNamespace + "FileSize").FirstOrDefault();
            var fileType = (string)document.Descendants(FileNamespace + "FileType").FirstOrDefault();
            var mimeType = (string)document.Descendants(FileNamespace + "MIMEType").FirstOrDefault();
            var type = mimeType.ToLower().Split('/')[0];
                        
            switch (type)
            {
                case "image":
                    builder = new ImageMetadataBuilder(document, fileSize, fileType, mimeType);
                    builder.SetCreateDate();
                    builder.SetModifyDate();
                    builder.SetImageWidth();
                    builder.SetImageHeight();
                    builder.SetImageSize();
                    break;
                case "document":
                    builder = new DocumentMetadataBuilder(document, fileSize, fileType, mimeType);
                    builder.SetCreateDate();
                    builder.SetModifyDate();
                    break;
            }
            return builder.GetMetadata();
        }
        private XElement GetFullXml(string filePath, string exifToolPath)
        {
            string args = string.Format("-X \"{0}\"", filePath);
            string output = RunProcess(exifToolPath, args);
            output = Sanitize(output);
            return new XElement("FullMetadata", XElement.Parse(output));
        }
        private string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        private string RunProcess(string exifToolPath, string args)
        {
            if (String.IsNullOrEmpty(exifToolPath))
                throw new SystemException("EXIFTool Executable Path Not Configured");
            if (!System.IO.File.Exists(exifToolPath))
                throw new SystemException("EXIFTool Executable Not Found: " + exifToolPath);
            var process = new Process
            {
                StartInfo =
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = exifToolPath,
                    Arguments = args
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
        private string Sanitize(string s)
        {
            return s.Replace("&", string.Empty);
        }
    }
