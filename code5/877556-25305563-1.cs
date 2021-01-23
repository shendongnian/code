    public abstract class ViewBase : UserControl, IView
    {
        public void SetPresenter(object presenter)
        {
            this.Tag = presenter;
        }
    }
