        private static void Main(string[] args)
        {
            using (Document doc = new Document(PageSize.A4, 36, 36, 36, 36))
            {
                using (PdfWriter pw = PdfWriter.GetInstance(doc, new FileStream("c:\\ImageTest.pdf", FileMode.Create)))
                {
                    pw.SetTagged();
                    pw.UserProperties = true;
                    doc.Open();
                    pw.PdfVersion = PdfWriter.VERSION_1_7;
                    Image img = Image.GetInstance(@"c:\images\WA.png");
                    img.SetAbsolutePosition(36, 592);
                    img.Alt = "Alt Text for Image!";
                    doc.Add(img);
                    doc.Close();
                }
            }
        }
