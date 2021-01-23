    enter code here
        private void canvas2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //create polyline
            polyline1 = new Polyline();
            polyline1.StrokeThickness = 4;
            polyline1.Stroke = Brushes.Black;
            Canvas.SetTop(polyline1, 0);
            Canvas.SetLeft(polyline1, 0);
        }
          
        private bool isPolyLine1Drog;
        double mousePosOnPolyline1X;
        double mousePosOnPolyline1Y;
        private void Polyline1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPolyLine1Drog = true;
            //get distance between current mouse position and top_left polyline
            mousePosOnPolyline1X= e.GetPosition(canvas2).X-Canvas.GetLeft(polyline1);
            mousePosOnPolyline1Y = e.GetPosition(canvas2).Y-Canvas.GetTop(polyline1);
            polyline1.CaptureMouse();
        }
        private void Polyline1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isPolyLine1Drog = false;
            polyline1.ReleaseMouseCapture();
        }
        private void Polyline1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPolyLine1Drog) return;
            //top=top+Y changing and left=left+X changing
            double left= e.GetPosition(canvas2).X - mousePosOnPolyline1X;
            double top = e.GetPosition(canvas2).Y - mousePosOnPolyline1Y;
            Canvas.SetLeft(polyline1, left);
            Canvas.SetTop(polyline1, top);
        }//mohsen_seif@yahoo.com
