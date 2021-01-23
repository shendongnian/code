    public interface INavigable
    {
        void Activate(object parameter);
        void Deactivate(object parameter);
        bool AllowGoingBack();
    }
