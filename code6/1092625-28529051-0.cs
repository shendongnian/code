    public ActionResult Avatar()
            {
                using (var bitmap = new Bitmap(50, 50))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.White);
                        using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#eeeeee")))
                        {
    
                            g.FillEllipse(b, 0, 0, 49, 49);
                        }
    
                        float emSize = 12;
                        g.DrawString("AM", new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular),
                            new SolidBrush(Color.Black), 10, 15);
                    }
    
                    using (var memStream = new System.IO.MemoryStream())
                    {
                        bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
                        var result = this.File(memStream.GetBuffer(), "image/png");
                        return result;
                    }
                }
            }
