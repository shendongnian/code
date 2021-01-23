    public void ReadSlide(){
                
                string filePath= @"C:\Users\UserName\Slide.pptx";
                Microsoft.Office.Interop.PowerPoint.Application PowerPoint_App = new Microsoft.Office.Interop.PowerPoint.Application();
                Microsoft.Office.Interop.PowerPoint.Presentations multi_presentations = PowerPoint_App.Presentations;
                Microsoft.Office.Interop.PowerPoint.Presentation presentation = multi_presentations.Open(filePath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
    
                string presentation_textforParent = "";
                foreach (var item in presentation.Slides[1].Shapes)
                {
                    var shape = (Microsoft.Office.Interop.PowerPoint.Shape)item;
                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.HasText == MsoTriState.msoTrue)
                        {
                            var textRange = shape.TextFrame.TextRange;
                            var text = textRange.Text;
    
                            presentation_textforParent += text + " ";
                        }
                    }
                }
    }
