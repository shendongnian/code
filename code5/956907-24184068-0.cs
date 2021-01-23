    private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       if (e.OriginalSource is Rectangle)
       {
           var myRectangle = e.OriginalSource as Rectangle;
           //your code for Rectangle clicked
       }
       else if (e.OriginalSource is Canvas)
       {
           var myCanvas = e.OriginalSource as Canvas;
           //your code for Canvas clicked
       }
    
    }
