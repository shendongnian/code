        public static void somefunction(string oldFile,string oldFile1,string pathout)
        {
            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            PdfReader reader1 = new PdfReader(oldFile1);
            Document document = new Document(PageSize.LEGAL.Rotate());
            // open the writer
            FileStream fs = new FileStream(pathout, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            // the pdf content
            PdfContentByte cb = writer.DirectContent;
            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            PdfImportedPage page1 = writer.GetImportedPage(reader1, 1);
            
            cb.AddTemplate(page, 0, 0);
            cb.AddTemplate(page1, 500, 0);
            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
            reader1.Close();
        }
