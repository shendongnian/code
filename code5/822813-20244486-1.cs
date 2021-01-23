    var pdfReader = new PdfReader(infilename);
    using (MemoryStream memoryStream = new MemoryStream())
    {
        PdfStamper stamper = new PdfStamper(pdfReader, memoryStream);
        for (int i = 0; i <= pdfReader.XrefSize; i++)
        {
            PdfDictionary pd = pdfReader.GetPdfObject(i) as PdfDictionary;
            if (pd != null)
            {
                PdfObject poAA = pd.Get(PdfName.AA); //Gets automatic execution objects
                PdfObject poJS = pd.Get(PdfName.JS); // Gets javascript objects
                PdfObject poJavaScript = pd.Get(PdfName.JAVASCRIPT); // Gets other javascript objects
                //use poJS.GetBytes(), poJS.ToString() etc to inspect details...
            }
        }
        stamper.Close();
        pdfReader.Close();
        File.WriteAllBytes(rawfile, memoryStream.ToArray());
    }
