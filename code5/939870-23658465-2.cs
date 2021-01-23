    private void CanvasMouseMove(object sender, MouseEventArgs e)
    {
        if (draggedImage != null)
        {
            var position = e.GetPosition(canvas);
            var offset = position - mousePosition;
            mousePosition = position;
            double left = Canvas.GetLeft(draggedImage) + offset.X;
            double top = Canvas.GetTop(draggedImage) + offset.Y;
    
            Point tl = SpecialPhoto.TranslatePoint(new Point(0, 0), canvas);
            Point br = SpecialPhoto.TranslatePoint(new Point(SpecialPhoto.ActualWidth, SpecialPhoto.ActualHeight), canvas);
            if (left < tl.X)
            {
                left = tl.X;
            }
            if (top < tl.Y)
            {
                top = tl.Y;
            }
            if (left + draggedImage.ActualWidth > br.X)
            {
                left = br.X - draggedImage.ActualWidth;
            }
            if (top + draggedImage.ActualHeight > br.Y)
            {
                top = br.Y - draggedImage.ActualHeight;
            }
            Canvas.SetLeft(draggedImage, left);
            Canvas.SetTop(draggedImage, top);
        }
    }
