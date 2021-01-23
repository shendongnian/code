    class ProgresBarAnimateBehavior : Behavior<ProgressBar>
    {
        bool _IsAnimating = false;
        protected override void OnAttached()
        {
            base.OnAttached();
            ProgressBar progressBar = this.AssociatedObject;
            progressBar.ValueChanged += ProgressBar_ValueChanged;
        }
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_IsAnimating)
                return;
            _IsAnimating = true;
            DoubleAnimation doubleAnimation = new DoubleAnimation
                (e.OldValue, e.NewValue, new Duration(TimeSpan.FromSeconds(0.3)), FillBehavior.Stop);
            doubleAnimation.Completed += Db_Completed;
            ((ProgressBar)sender).BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);
            e.Handled = true;
        }
        private void Db_Completed(object sender, EventArgs e)
        {
            _IsAnimating = false;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            ProgressBar progressBar = this.AssociatedObject;
            progressBar.ValueChanged -= ProgressBar_ValueChanged;
        }
    }
