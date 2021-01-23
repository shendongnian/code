    [DefaultEvent(typeof(ScrollViewer),"DoubleTapped")]
    public class ScrollViewerDoubleTap : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            ScrollViewer sv = (ScrollViewer)sender;
            if (sv.HorizontalScrollBarVisibility == ScrollBarVisibility.Disabled)
            {
                sv.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                sv.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            return sender;
        }
    }
