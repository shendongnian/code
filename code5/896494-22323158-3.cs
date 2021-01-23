    public interface IView
    {
        bool CanClose();
    }
    public UserControl View1: IView
    {
        public bool CanClose()
        {
           ...
        }
    }
    public UserControl View2: IView
    {
        public bool CanClose()
        {
           ...
        }
    }
