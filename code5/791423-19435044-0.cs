    using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open("mydoc.docx", true))
    {
      MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;
        
      // Search for your footer part here.
      // Just for the sake of simplicity I take the second footer part.
      FooterPart fp = mainPart.FooterParts.ToList()[2];                
      // Create new image part.
      ImagePart ip = fp.AddImagePart(ImagePartType.Jpeg);
        
      using (FileStream fs = File.Open("mypicture.jpg", FileMode.Open))
      {         
        ip.FeedData(fs);         
      }
      string relationshipId = fp.GetIdOfPart(ip);
      // Create the image element using your function.
      Drawing img = CreateImage(relationshipId);
      Run r = new Run(img);
      Paragraph para = fp.RootElement.Descendants<Paragraph>().FirstOrDefault();
      if(para != null)
      {
        para.Append(r);   
      }      
      else
      {
        Console.WriteLine("paragraph is null...");
      }
    }
