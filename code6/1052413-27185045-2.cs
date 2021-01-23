    public class MyTreeView : TreeView
    {
        public event Action SomeItemLostFocus;
        public MyTreeView()
        {
            DefaultStyleKey = typeof(MyTreeView);
        }
        public override void OnLostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (SomeItemLostFocus != null)
                SomeItemLostFocus();
        }
    }
