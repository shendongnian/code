    public static void AddText(string pdfName, string filePath, string textToStamp, float? x = null, float? y = null)
    {
        //x and y are used to position the text and allow multiple different templates to use the same method
        //Designate the Temporary source to be used
        string tempPath = @"C:\TemporaryFilePath\" + pdfName + "";
        //Copy to file to the source path
        File.Copy(filePath, tempPath);
        PdfReader reader = new PdfReader(tempPath);
        iTextSharp.text.Rectangle pageSize = reader.GetPageSizeWithRotation(1);
        //Convert the pageHeight into a float
        int pageHeight = Convert.ToInt32(pageSize.Height);
        PdfStamper stamper = new PdfStamper(reader, new FileStream(filePath, FileMode.Create));
         
        PdfContentByte canvas = stamper.GetOverContent(1);
        //Set a default value if x and y have no value 
        if (x.HasValue == false)
        {
            x = 35;
        }
        if (y.HasValue == false)
        {
            y = 30;
        }
        //choose the font type 
        var FontColour = new BaseColor(255, 255, 255);
        var MyFont = FontFactory.GetFont("Times New Roman", 10, FontColour);
        ColumnText.ShowTextAligned
                    (canvas, Element.ALIGN_LEFT, new Phrase("Hello World", MyFont), (float)x, pageHeight - (float)y, 0);
        
        stamper.Close();
        reader.Close();
        File.Delete(tempPath);
    }
