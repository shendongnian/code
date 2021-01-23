    public class ExtendedTextBlock2 : TextBlock
    {
        private TextBlock _left, _right;
        public string RightAlignedText
        {
            get { return (string)GetValue(RightAlignedTextProperty); }
            set { SetValue(RightAlignedTextProperty, value); }
        }
        public static readonly DependencyProperty RightAlignedTextProperty =
            DependencyProperty.Register("RightAlignedText", typeof(string), typeof(ExtendedTextBlock2), new PropertyMetadata(SetText));
        public string LeftAlignedText
        {
            get { return (string)GetValue(LeftAlignedTextProperty); }
            set { SetValue(LeftAlignedTextProperty, value); }
        }
        public static readonly DependencyProperty LeftAlignedTextProperty =
            DependencyProperty.Register("LeftAlignedText", typeof(string), typeof(ExtendedTextBlock2), new PropertyMetadata(SetText));
                public static void SetText(object sender, DependencyPropertyChangedEventArgs args)
        {
            ((ExtendedTextBlock2)sender).SetText();
        }
        public void SetText()
        {
            if (_left == null || _right == null)
                return;
            _left.Text = LeftAlignedText;
            _right.Text = RightAlignedText;
        }
        public ExtendedTextBlock2()
        {
            Loaded += ExtendedTextBlock2_Loaded;
        }
        void ExtendedTextBlock2_Loaded(object sender, RoutedEventArgs e)
        {
            Inlines.Clear();
            var child = new InlineUIContainer();
            var container = new Grid();
            var widthBinding = new Binding { Source = this, Path = new PropertyPath(TextBlock.ActualWidthProperty) };
            container.SetBinding(Grid.WidthProperty, widthBinding);
            child.Child = container;
            container.Children.Add(_left = new TextBlock { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
            container.Children.Add(_right = new TextBlock { HorizontalAlignment = System.Windows.HorizontalAlignment.Right });
            Inlines.Add(child);
            SetText();
        }
    }
