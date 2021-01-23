    ImageAttributes imgA = new ImageAttributes();
    ColorMap cm = new ColorMap();
    cm.OldColor = Color.Black
    cm.NewColor = Color.FromArgb((byte)(0.7*255), Color.Green);
    imgA.SetRemapTable(new ColorMap[] {cm });         
    GraphicsUnit gu = GraphicsUnit.Pixel;   
    g.DrawImage(imageToDraw,new Point[]{Point.Empty, 
                                        new Point(backImage.Width/2,0), 
                                        new Point(0,backImage.Height/2)},
                            Rectangle.Round(imageToDraw.GetBounds(ref gu)), 
                            GraphicsUnit.Pixel, imgA);
