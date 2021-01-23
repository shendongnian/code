    public class CustomScrollViewer : ScrollViewer
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            // Do nothing!
               // or
           // base.OnMouseLeftButtonDown(e) ; e.handled = false; --to support selection //in the ScrollViewer .didn't try this one though!!
        }
    }
