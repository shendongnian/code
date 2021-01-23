    public class MyPageTransition : ContentControl
    {
        public static readonly DependencyProperty CurrentPageProperty = 
            DependencyProperty.Register(
                "CurrentPage", 
                typeof(object), 
                typeof(MyPageTransition), 
                new PropertyMetadata(DependencyPropertyChanged));
        public ContentControl()
        {
            this.Content = this.pageTransition;
        }
        public object CurrentPage
        {
            get { return GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }
        protected static void DependencyPropertyChanged(
            DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == CurrentPageProperty)
            {
                this.pageTransition.ShowPage(CurrentPage);
            }
        }
        private PageTransition pageTransition = new PageTransition();
    }
