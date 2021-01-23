    public class MyTreeView : TreeView
    {
        public event Action SomeItemLostFocus;
        public MyTreeView()
        {
            DefaultStyleKey = typeof(MyTreeView);
        }
        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (SomeItemLostFocus != null)
                SomeItemLostFocus();
        }
    }
