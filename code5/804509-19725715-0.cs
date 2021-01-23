    public partial class YourUserControl : UserControl
    {
        ...
        public event RoutedEventHandler Click
        {
            add { AddHandler(MenuItem.ClickEvent, value); }
            remove { RemoveHandler(MenuItem.ClickEvent, value); }
        }
    }
