    public partial class LongListSelectorItemControl
    {
 
       public static readonly DependencyProperty TitleProperty =
                DependencyProperty.Register("Title", typeof(string), typeof(LongListSelectorItemControl), new PropertyMetadata(default(string), TitlePropertyChanged));
    
            private static void TitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                TitleTextBlock.Text = e.NewValue as string;
            }
    
            public string Title
            {
                get { return (string) GetValue(TitleProperty); }
                set { SetValue(TitleProperty, value); }
            }
    ....
    }
