    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public ShellViewModel()
        {
            Width = 500;
        }
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }
        public void MyButton()
        {
            Width = 800;
        }
    }
