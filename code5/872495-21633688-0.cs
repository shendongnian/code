    static void manipulatePdf(String src, String dest)
        {
            PdfReader reader = new PdfReader(src);
            PdfDictionary dict = reader.GetPageN(1);
            PdfObject pdfObject = dict.GetDirectObject(PdfName.CONTENTS);
            if (pdfObject.IsStream()) {
                PRStream stream = (PRStream)pdfObject;
                byte[] data = PdfReader.GetStreamBytes(stream);
                stream.SetData(System.Text.Encoding.ASCII.GetBytes(System.Text.Encoding.ASCII.GetString(data).Replace("Hello World", "HELLO WORLD")));
            }
            FileStream outStream = new FileStream(dest, FileMode.Create);
            PdfStamper stamper = new PdfStamper(reader, outStream);
            reader.Close();
        }
