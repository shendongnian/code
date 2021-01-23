    public partial class MyUserControl : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyUserControl),
            new PropertyMetadata((d, a) => ((MyUserControl)d).TextChanged()));
        private void TextChanged()
        {
            someTextBlock.Text = Text;
        }
    }
