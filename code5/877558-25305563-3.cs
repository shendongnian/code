    public abstract class ViewBase : UserControl, IView
    {
        public object Presenter
        {
            set { this.Tag = value; }
        }
    }
