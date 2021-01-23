        public bool IsSpinning
        {
            get { return (bool)GetValue(IsSpinningProperty); }
            set { SetValue(IsSpinningProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsSpinning.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSpinningProperty =
            DependencyProperty.Register("IsSpinning", typeof(bool), typeof(ProgressWaitSpinner), new PropertyMetadata(false, OnIsSpinningChanged));
        private static void OnIsSpinningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MainWindow).Visibility = Visibility.Hidden;
            if (((bool)e.NewValue) == true)
            {
                (d as ProgressWaitSpinner).Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                (d as ProgressWaitSpinner).Visibility = System.Windows.Visibility.Hidden;
            }
        }
