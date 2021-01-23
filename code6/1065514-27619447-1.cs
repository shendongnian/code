    void Grid_PreviewMouseWheel(ScrollViewer scrollViewer, MouseWheelEventArgs e)
    {
        e.Handled=true;
        bool isCtrl = Keyboard.IsKeyDown(Key.LeftCtrl);
        if (isCtrl)
        {
            if (e.Delta > 0)
                scrollViewer.LineUp();
            else
                scrollViewer.LineDown();
         }
    }
