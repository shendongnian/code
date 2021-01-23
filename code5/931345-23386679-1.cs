    selectionRectangle.MouseMove += new MouseEventHandler(Rectangle_MouseMove_1);
    
    private bool drag = false;
    private Point startPt;
    private int wid;
    private int hei;
    private Point lastLoc;
    private double CanvasLeft, CanvasTop;
    private void Rectangle_MouseMove_1(object sender, MouseEventArgs e)
    {
        try
        {
            if (drag)
            {
                    var newX = (startPt.X + (e.GetPosition(BackPanel).X - startPt.X));
                    var newY = (startPt.Y + (e.GetPosition(BackPanel).Y - startPt.Y));
                    Point offset = new Point((startPt.X - lastLoc.X), (startPt.Y - lastLoc.Y));
                    CanvasTop = newY - offset.Y;
                    CanvasLeft = newX - offset.X;
                    // check if the drag will pull the rectangle outside of it's host canvas before performing
                    // TODO: protect against lower limits too...
                   if ((CanvasTop + selectionRectangle.Height > BackPanel.Height) || (CanvasLeft + selectionRectangle.Width > BackPanel.Width) || CanvasTop < 0 || CanvasLeft < 0)
                        {
                            return;
                        }
                    selectionRectangle.SetValue(Canvas.TopProperty, CanvasTop);
                    selectionRectangle.SetValue(Canvas.LeftProperty, CanvasLeft);               
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);    
        }
    }
