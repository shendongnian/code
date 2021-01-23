    public class CropControl : UserControl 
    {
        public Rect Selection
        {
            get { return (Rect)GetValue(SelectionProperty); }
            set { SetValue(SelectionProperty, value); }
        }
        public static readonly DependencyProperty SelectionProperty =
            DependencyProperty.Register("Selection", typeof(Rect), typeof(CropControl), new PropertyMetadata(default(Rect)));
        // this is used, to react on changes from ViewModel. If you assign a  
        // new Rect in your ViewModel you will have to redraw your Rect here
        private static void OnSelectionChanged(System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            Rect newRect = (Rect)e.NewValue;
            Rectangle selectionRectangle = d as Rectangle;
            
            if(selectionRectangle!=null)
                return;
            
            selectionRectangle.SetValue(Canvas.LeftProperty, newRect.X);
            selectionRectangle.SetValue(Canvas.TopProperty, newRect.Y);
            selectionRectangle.Width = newRect.Width;
            selectionRectangle.Height = newRect.Height;
        }
        
        private void LoadedImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isDragging == false)
            {
                anchorPoint.X = e.GetPosition(BackPanel).X;
                anchorPoint.Y = e.GetPosition(BackPanel).Y;
                Canvas.SetZIndex(selectionRectangle, BackPanel.Children.Count);
                isDragging = true;
                BackPanel.Cursor = Cursors.Cross;
            }
        }
        private void LoadedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                double x = e.GetPosition(BackPanel).X;
                double y = e.GetPosition(BackPanel).Y;
                selectionRectangle.SetValue(Canvas.LeftProperty, Math.Min(x, anchorPoint.X));
                selectionRectangle.SetValue(Canvas.TopProperty, Math.Min(y, anchorPoint.Y));
                selectionRectangle.Width = Math.Abs(x - anchorPoint.X);
                selectionRectangle.Height = Math.Abs(y - anchorPoint.Y);
                if (selectionRectangle.Visibility != Visibility.Visible)
                    selectionRectangle.Visibility = Visibility.Visible;
            }
        }
        private void LoadedImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                if (selectionRectangle.Width > 0)
                {
                    Crop.IsEnabled = true;
                    Cut.IsEnabled = true;
                    BackPanel.Cursor = Cursors.Arrow;
                }
                // Set the Selection to the new rect, when the mouse button has been released
                Selection = new Rect(
                    selectionRectangle.GetValue(Canvas.LeftProperty), 
                    selectionRectangle.GetValue(Canvas.TopProperty), 
                    selectionRectangle.Width,
                    selectionRectangle.Height);
            }
        }
    }
