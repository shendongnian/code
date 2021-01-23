        static void Main(string[] args)
        {
            byte[] file_bytes = File.ReadAllBytes(@"./legit.pdf");
            byte[] modified_bytes = GeneratePDFByte(file_bytes);
            File.WriteAllBytes(@"./modified.pdf", modified_bytes);
        }
        private static byte[] GeneratePDFByte(byte[] pdf_bytes)
        {
            PdfReader reader = new PdfReader(pdf_bytes);
            using (var ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms))
                {
                    PdfFileSpecification pfs = PdfFileSpecification.Url(stamper.Writer, "https://itextpdf.com/sites/default/files/styles/max_1300x1300/public/2019-08/Octocat.png");
                    stamper.AddFileAttachment("file", pfs);
                }
                reader.Close();
                return ms.ToArray();
            }
        }
