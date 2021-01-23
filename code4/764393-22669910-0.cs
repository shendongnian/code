    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Asus\Desktop\Test.pdf", FileMode.OpenOrCreate));
            doc.AddDocListener(writer);
            doc.Open();
            doc.Add(new Annotation("annotation", "The text displayed in the sticky note", 100f, 500f, 200f, 600f));
            doc.Close();
