        public void AddWaterMarkToPowerPoint(string filePath)
        {
            string waterMarkText = "Top secret";
            PowerPoint.Application powerPointApp = new PowerPoint.Application();
            PowerPoint.Presentations pres = powerPointApp.Presentations;
            string imagePath = null;
            try
            {
                PowerPoint.Presentation pptPresentation = pres.Open(filePath, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
                PowerPoint.PageSetup pageSetup = pptPresentation.PageSetup;
                float pageWidth = pageSetup.SlideWidth;
                float pageHeight = pageSetup.SlideHeight;
                CreateTempWaterMarkImage(waterMarkText, ref imagePath, (int)pageHeight, (int)pageWidth);
                for (int i = 1; i <= pptPresentation.Slides.Count; i++)
                {
                    PowerPoint.Slide slide = pptPresentation.Slides[i];
                    PowerPoint.Shapes shapes = slide.Shapes;
                    PowerPoint.Shape shape = shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, 0, 0, pageWidth, pageHeight);
                    shape.Fill.UserPicture(imagePath);
                    shape.Fill.Transparency = 0.7f;
                    shape.Line.Transparency = 1;
                    shape.ZOrder(MsoZOrderCmd.msoBringToFront);
                }
                pptPresentation.SaveAs(filePath);
                pptPresentation.Close();
            }
            catch (Exception ex)
            {
                //log exception
                throw;
            }
            finally
            {
                // Cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                powerPointApp.Quit();
                //remove temp image
                if (imagePath != null)
                    File.Delete(imagePath);
            }
        }
    private void CreateTempWaterMarkImage(string waterMarkText, ref string imagePath, int pageHeight, int pageWidth)
    {
        float angleRotation = (float)((Math.Atan2((double)pageHeight, (double)pageWidth) * 180) / Math.PI);
        float fontSize = (float)Math.Sqrt(Math.Pow(pageHeight, 2) + Math.Pow(pageWidth, 2)) / 50;
        using (Bitmap newie = new Bitmap(pageWidth, pageHeight))
        {
            using (Graphics gr = Graphics.FromImage(newie))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TranslateTransform((float)pageWidth / 2f, (float)pageHeight / 2f);
                gr.RotateTransform(-angleRotation);
                Font font = new Font("Arial", fontSize, FontStyle.Regular);
                SizeF textSize = gr.MeasureString(companyName, font);
                gr.DrawString(waterMarkText, font, SystemBrushes.GrayText, -textSize.Width, -textSize.Height);
            }
            string fileName = Path.GetRandomFileName();
                imagePath = Path.GetTempPath() + @"\" + fileName + ".png";
                newie.Save(imagePath, ImageFormat.Png);
            }
        }
