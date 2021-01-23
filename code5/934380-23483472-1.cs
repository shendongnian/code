        #region Caption (DependencyProperty)
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(CaptionGuy),
              new PropertyMetadata{PropertyChangedCallback = CaptionChanged});
        private static void CaptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CaptionGuy cg = d as CaptionGuy;
            if (cg != null && e.NewValue!=null)
            {
                cg.CaptionLabel.Content = e.NewValue.ToString();
            }
        }
        #endregion
