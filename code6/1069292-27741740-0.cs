    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new Application { Visible = MsoTriState.msoTrue };
            Presentation pres = app.Presentations.Open(@"C:\test.pptx");
            for (int slideCount = 1; slideCount <= pres.Slides.Count; slideCount++)
            { 
                int bulletCount = 0;
                foreach (object item in pres.Slides[slideCount].Shapes) //get all objects in all slides
                {
                    var shape = (Microsoft.Office.Interop.PowerPoint.Shape)item;
                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                    {
                        var paragraphs = shape.TextFrame2.TextRange.Paragraphs;
                        for (int i = 1; i <= paragraphs.Count; i++)
                        {
                            BulletFormat2 bulletFormat2 = paragraphs.Item(i).ParagraphFormat.Bullet;
                            if (bulletFormat2.Type != MsoBulletType.msoBulletNone)
                            {
                                //this paragraph has has bullet
                                bulletCount++;
                            }
                        }
                        if (bulletCount > 4)
                        {
                            //create new slide, cut this paragraph and paste in the new slide
                            Slide tempSlide = pres.Slides.AddSlide(2, pres.Slides[1].CustomLayout);
                            paragraphs.Item(slideCount).Cut();
                            tempSlide.Shapes[2].TextFrame.TextRange.Paste(); 
                        }
                    }
                }
            }
            pres.Save();
            pres.Close();
            app.Quit();
        }
    }
