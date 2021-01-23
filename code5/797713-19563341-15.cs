    public class LabeledPointMarker : ElementPointMarker
    {
        #region TextProperty
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(LabeledPointMarker));
    
        public string Text
        {
            get { return (string)this.GetValue(LabeledPointMarker.TextProperty); }
            set { this.SetValue(LabeledPointMarker.TextProperty, value); }
        }
        #endregion TextProperty
    
        // ...
        // Another dependency properties in the same manner.
        // ...
    
        public override UIElement CreateMarker()
        {
            TextBlock tb = new TextBlock()
            {
                Text = this.Text,
                Foreground = this.TextBrush
            };
    
            Border b = new Border()
            {
                BorderBrush = this.BorderBrush,
                BorderThickness = this.BorderThickness,
                Background = this.BorderBackground,
                Child = tb
            };
    
            return b;
        }
    
        public override void SetPosition(UIElement marker, Point screenPoint)
        {
            Canvas.SetLeft(marker, screenPoint.X - marker.DesiredSize.Width / 2);
            Canvas.SetTop(marker, screenPoint.Y - marker.DesiredSize.Height / 2);
        }
    }
