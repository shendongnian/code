    public static readonly DependencyProperty ButtonText = DependencyProperty.Register("BText", typeof(string), typeof(ButtonImage), new PropertyMetadata(ButtonTextChanged));
        private static void ButtonTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            txtButtonText.Text = e.NewValue;
        }
