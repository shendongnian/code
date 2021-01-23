    static void Main(string[] args)
    {
      InsertAPicture("mydoc.docx", "mypic.jpg");      
    }
    public static void InsertAPicture(string document, string fileName)
    {
      using (WordprocessingDocument wordprocessingDocument =
          WordprocessingDocument.Open(document, true))
      {
        MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;
        Uri imageUri = new Uri("/word/media/" +
          System.IO.Path.GetFileName(fileName), UriKind.Relative);
        // Create "image" part in /word/media
        // Change content type for other image types.
        PackagePart packageImagePart = 
          wordprocessingDocument.Package.CreatePart(imageUri, "Image/jpeg");
        // Feed data.
        byte[] imageBytes = File.ReadAllBytes(fileName);
        packageImagePart.GetStream().Write(imageBytes, 0, imageBytes.Length);
        
        PackagePart documentPackagePart = 
          mainPart.OpenXmlPackage.Package.GetPart(new Uri("/word/document.xml", UriKind.Relative));
        Console.Out.WriteLine(documentPackagePart.Uri);
        
        // URI to the image is relative to releationship document.
        PackageRelationship imageReleationshipPart = documentPackagePart.CreateRelationship(
              new Uri("media/" + System.IO.Path.GetFileName(fileName), UriKind.Relative),
              TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/image");
        AddImageToBody(wordprocessingDocument, imageReleationshipPart.Id);
      }
    }
    private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
    {
      var element =
           new Drawing(
               new DW.Inline(
                   new DW.Extent() { Cx = 990000L, Cy = 792000L },
                   new DW.EffectExtent()
                   {
                     LeftEdge = 0L,
                     TopEdge = 0L,
                     RightEdge = 0L,
                     BottomEdge = 0L
                   },
                   new DW.DocProperties()
                   {
                     Id = (UInt32Value)1U,
                     Name = "Picture 1"
                   },
                   new DW.NonVisualGraphicFrameDrawingProperties(
                       new A.GraphicFrameLocks() { NoChangeAspect = true }),
                   new A.Graphic(
                       new A.GraphicData(
                           new PIC.Picture(
                               new PIC.NonVisualPictureProperties(
                                   new PIC.NonVisualDrawingProperties()
                                   {
                                     Id = (UInt32Value)0U,
                                     Name = "New Bitmap Image.jpg"
                                   },
                                   new PIC.NonVisualPictureDrawingProperties()),
                               new PIC.BlipFill(
                                   new A.Blip(
                                       new A.BlipExtensionList(
                                           new A.BlipExtension()
                                           {
                                             Uri =
                                               "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                           })
                                   )
                                   {
                                     Embed = relationshipId,
                                     CompressionState =
                                     A.BlipCompressionValues.Print
                                   },
                                   new A.Stretch(
                                       new A.FillRectangle())),
                               new PIC.ShapeProperties(
                                   new A.Transform2D(
                                       new A.Offset() { X = 0L, Y = 0L },
                                       new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                   new A.PresetGeometry(
                                       new A.AdjustValueList()
                                   ) { Preset = A.ShapeTypeValues.Rectangle }))
                       ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
               )
               {
                 DistanceFromTop = (UInt32Value)0U,
                 DistanceFromBottom = (UInt32Value)0U,
                 DistanceFromLeft = (UInt32Value)0U,
                 DistanceFromRight = (UInt32Value)0U,
                 EditId = "50D07946"
               });
      wordDoc.MainDocumentPart.Document.Body.AppendChild(
        new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
          new DocumentFormat.OpenXml.Wordprocessing.Run(element)));
    }
