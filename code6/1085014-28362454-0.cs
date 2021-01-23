    public class ViewModel : INotifyPropertyChanged
    {
        public List<object> A { get; private set; }
        public ViewModel()
        {
            this.A = new List<object> { Brushes.BlueViolet, 42, false };
        }
    }
