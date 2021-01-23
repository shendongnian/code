    string FileLocation = @"C:\\test\\pdfFileName.pdf"; // file path of pdf file
    var uri = new Uri(@"pack://application:,,,/projrct_name;component/View/Icons/funnelGreen.png"); // use image from project/application folder (this image will insert to pdf)
    var resourceStream = Application.GetResourceStream(uri).Stream; 
    PdfReader pdfReader = new PdfReader(FileLocation);
    PdfStamper stamp = new PdfStamper(pdfReader, new FileStream(FileLocation.Replace(".pdf", "(tempFile).pdf"), FileMode.Create));iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(resourceStream), System.Drawing.Imaging.ImageFormat.Png);
    img.SetAbsolutePosition(125, 350); // set the position in the document where you want the watermark to appear.
    img.ScalePercent(35f);// not neccessory, use if you want to adjust image
    img.ScaleToFit(140f, 100f); // not neccessory, use if you want to adjust image 
    PdfContentByte waterMark;
    
    for (int page = 1; page <= pdfReader.NumberOfPages; page++) // for loop will add image to each page. Based on the condition you can add image to single page also 
    {
            waterMark = stamp.GetOverContent(page);
    	waterMark.AddImage(img);
    }
    
    stamp.FormFlattening = true;
    stamp.Close();// closing the pdfStamper, the order of closing must be important
    pdfReader.Close();
    
    File.Delete(FileLocation);
    File.Move(FileLocation.Replace(".pdf", "(tempFile).pdf"), FileLocation);
