    public static Image GetBarCode(this string data, int fontSizeEm)
            {
                data = "*" + data + "*";
                Image img = null;
                Graphics drawing = null;
                try
                {
                    using (var pfc = new PrivateFontCollection())
                    {
                        pfc.AddFontFile(@"{{PATH TO YOUR FONT}}");
                        using (var myfont = new Font(pfc.Families[0], fontSizeEm))
                        {
                            img = new Bitmap(1, 1);
                            drawing = Graphics.FromImage(img);
                            var textSize = drawing.MeasureString(data, myfont);
                            img.Dispose();
                            drawing.Dispose();
                            img = new Bitmap((int) textSize.Width, (int) textSize.Height);
                            drawing = Graphics.FromImage(img);
                            drawing.DrawString(data, myfont, new SolidBrush(Color.Black), 0, 0);
                        }
                        drawing.Save();
                    }
                    return img;
                }
                catch
                {
                    //Handle exception
                    return null;
                }
                finally
                {
                    if(drawing!= null)
                        drawing.Dispose();
                }
            }
