    public abstract class ViewBase : UserControl, IView
    {
        object Presenter
        {
            set { this.Tag = value; }
        }
    }
