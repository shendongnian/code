    class UpperTextBlock : TextBlock
    {
        public string UpperText
        {
            get { return (string)GetValue(UpperTextProperty); }
            set { SetValue(UpperTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for UpperText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpperTextProperty =
            DependencyProperty.Register("UpperText", typeof(string), typeof(UpperTextBlock), new PropertyMetadata(string.Empty, OnCurrentReadingChanged));
        private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpperTextBlock txt = d as UpperTextBlock;
            txt.Text = txt.UpperText.ToUpper();
        }
    }
     <local:UpperTextBlock UpperText="test"/>
