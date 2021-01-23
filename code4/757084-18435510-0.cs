    public LabelPage : Page
    {
        public virtual void SetUpAnimation()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -nameLabel.ActualWidth;
            doubleAnimation.To = nameCanvas.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:10"));
            nameLabel.BeginAnimation(Canvas.RightProperty, doubleAnimation);
        }
    }
