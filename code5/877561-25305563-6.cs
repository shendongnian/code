    public abstract class ViewBase : UserControl, IView
    {
        private object _presenter;
        public object Presenter
        {
            set { this._presenter = value; }
        }
    }
