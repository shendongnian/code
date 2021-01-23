    enter code here
        private bool isPolyLine1Drog;
        double mousePosOnPolyline1X;
        double mousePosOnPolyline1Y;
        private void Polyline1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPolyLine1Drog = true;
            mousePosOnPolyline1X= e.GetPosition(canvas2).X;
            mousePosOnPolyline1Y = e.GetPosition(canvas2).Y;         
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
            // get distance between MouseLeftButtonDown point and MouseLeftButtonUp point
            double left= e.GetPosition(canvas2).X - mousePosOnPolyline1X;
            double top = e.GetPosition(canvas2).Y - mousePosOnPolyline1Y;
            Canvas.SetLeft(polyline1, left);
            Canvas.SetTop(polyline1, top);
        }//mohsen_seif@yahoo.com
