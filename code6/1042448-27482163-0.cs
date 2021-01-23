    public void AddWaterMarkToPowerPoint(string filePath)
            {
                string waterMarkText = "Top secret";
    
                PowerPoint.Application ppApp = new PowerPoint.Application();
    
                PowerPoint.Presentations pres = ppApp.Presentations;
    
    
                PowerPoint.Presentation pptPresentation = pres.Open(filePath, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
    
    
                for (int i = 1; i <= pptPresentation.Slides.Count; i++)
                {
                    var test = pptPresentation.Slides[i].CustomLayout.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 200, 200, 600, 100);
    
                    test.TextFrame.TextRange.Text = waterMarkText;
                    test.Rotation = -45;
                    test.TextFrame.TextRange.Font.Color.RGB = Color.LightGray.ToArgb();
                    test.TextFrame.TextRange.Font.Size = 48;
    
                }
    
                pptPresentation.SaveAs(filePath);
    
                pptPresentation.Close();
    
    
    
            }
