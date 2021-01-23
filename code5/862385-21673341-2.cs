    /// <summary>
    /// Interface for managing a spinner
    /// </summary>
    public interface IManageASpinner
    {
        bool IsVisible {get;set;}
        // Add any other properties or methods you might need.
    }
    /// <summary>
    /// A singleton spinner ViewModel for the main window spiner
    /// </summary>
    public class SpinnerViewModel : INotifyPropertyChanged, IManageASpinner
    {        #region Singleton and Constructor
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static SpinnerViewModel Instance
        {
            get { return _Instance ?? (_Instance = new SpinnerViewModel()); }
        } private static SpinnerViewModel _Instance;
        /// <summary>
        /// Private constructor to prevent multiple instances
        /// </summary>
        private SpinnerViewModel()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Is the spinner visible or not? 
        /// Xaml Binding: {Binding Source={x:Static svm:SpinnerViewModel.Instance}, Path=IsVisible}
        /// </summary>
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged("IsVisible");
            }
        } private bool _IsVisible;
        // Add any other properties you might want to include
        // such as IsSpinning, etc..
        #endregion
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
