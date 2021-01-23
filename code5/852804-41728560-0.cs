    Bitmap image = new Bitmap(@"C:\Users\Eric\Desktop\Text Pictures\Oil0.bmp");
    
    tessnet2.Tesseract ocr = new tessnet2.Tesseract();
    
    
    
    ocr.Init(@"C:\DontPointToTessDataDirectly", "eng", true); 
    
    List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty); // Error occurs here
    
    foreach (tessnet2.Word word in result)
         Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
