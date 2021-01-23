    // Class constructor
    public YourClass(Canvas theCanvas) //You may not need the Canvas as an argument depending on your scope
        {
            panTransform = new TranslateTransform();
            zoomTransform = new ScaleTransform();
            bothTransforms = new TransformGroup();
            
            bothTransforms.Children.Add(panTransform);
            bothTransforms.Children.Add(zoomTransform);
            
            theCanvas.RenderTransform = bothTransforms;
            
            //Handler
            theCanvas.MouseWheel += wheelEvent;
            //You also need your own handlers for panning, which I'm not showing here.
        }
    private void returnCalculatedScale()
        {
            double d;
            //Do some math to get a new scale. I keep track of an integer, and run it through the formula y^(x/3) where X is the integer.
            
            return d;
        }
    // Mouse wheel handler, where the magic happens
    private void wheelEvent(object sender, MouseWheelEventArgs e)
        {
            Point position = e.GetPosition(mainCanvas);           
                        
            zoomTransform.CenterX = position.X;
            zoomTransform.CenterY = position.Y;
            zoomTransform.ScaleX = returnCalculatedScale();
            zoomTransform.ScaleY = returnCalculatedScale();
            Point cursorpos = Mouse.GetPosition(mainCanvas); //This was the secret, as the mouse position gets out of whack when the transform occurs, but Mouse.GetPosition lets us get the point accurate to the transformed canvas.
            double discrepancyX = cursorpos.X - position.X;
            double discrepancyY = cursorpos.Y - position.Y;
            //If your canvas is already panned an arbitrary amount, this aggregates the discrepancy to the TranslateTransform.
            panTransform.X += discrepancyX;
            panTransform.Y += discrepancyY;
