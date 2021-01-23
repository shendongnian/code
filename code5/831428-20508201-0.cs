            public static string MainStamping(string docname, List<string> imagePath, string mediaField)
            {
                string filename = ConfigurationManager.AppSettings["LocalFolder"] + docname + ".pdf";
    
                FileStream pdfOutputFile = new FileStream(filename, FileMode.Create);
                PdfConcatenate pdfConcatenate = new PdfConcatenate(pdfOutputFile);
                
                PdfReader result = null;
    
                for (int i = 0; i < imagePath.Count; i++)
                {
                    result = CreatePDFDocument1(imagePath[i], mediaField);
                    pdfConcatenate.AddPages(result);
                }
    
                pdfConcatenate.Close();
                return filename;
            }
    
            public static PdfReader CreatePDFDocument1(string imagePath, string mediaField)
            {
                PdfReader pdfReader = null;
                string pdfPortrait = ConfigurationManager.AppSettings["PdfPortraitTemplate"];
                string pdfLandscape = ConfigurationManager.AppSettings["PdfLandscapeTemplate"];
    
                iTextSharp.text.Image instanceImg = iTextSharp.text.Image.GetInstance(imagePath);
    
                if ((instanceImg.ScaledHeight >= instanceImg.ScaledWidth) || (instanceImg.ScaledWidth <= 714 ))
                {
                    pdfReader = new PdfReader(pdfPortrait);
                }
                else
                {
                    pdfReader = new PdfReader(pdfLandscape);
                }
    
                MemoryStream memoryStream = new MemoryStream();
                PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
    
                AcroFields testForm = pdfStamper.AcroFields;
                testForm.SetField("MediaField", mediaField);
    
                PdfContentByte overContent = pdfStamper.GetOverContent(1);
                IList<AcroFields.FieldPosition> fieldPositions = testForm.GetFieldPositions("ImageField");
    
                if (fieldPositions == null || fieldPositions.Count <= 0) throw new ApplicationException("Error locating field");
                AcroFields.FieldPosition fieldPosition = fieldPositions[0];
                iTextSharp.text.Rectangle imageRect = new Rectangle(fieldPosition.position.Top, fieldPosition.position.Left, fieldPosition.position.Bottom, fieldPosition.position.Right);
    
                instanceImg.ScaleToFit(imageRect.Height, -1 * imageRect.Width);
                instanceImg.SetAbsolutePosition(fieldPosition.position.Left, (fieldPosition.position.Top - (instanceImg.ScaledHeight)));
    
                overContent.AddImage(instanceImg);
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
    
                PdfReader resultReader = new PdfReader(memoryStream.ToArray());
                pdfReader.Close();
    
                return resultReader;
            }
