    public class EncryptViewModel : ViewModelBase, IViewModelInterface, IDataErrorInfo
    {
        ...
        /// <summary>
        /// View Name
        /// </summary>
        public string Name { get { return "Encrypt"; } }
        /// <summary>
        /// Model has been loaded
        /// </summary>
        void IViewModelInterface.Loaded()
        {
            if (0 == Interlocked.Exchange(ref _Locked, 1))
            {
                try
                {
                    StatusMessage(NotificationMessages.StatusEncrypt);
                    ResetData(CommandTags.Reset, true);
                }
                finally
                {
                    Interlocked.Exchange(ref _Locked, 0);
                }
            }
        }
        /// <summary>
        /// MainWindow ViewModel
        /// </summary>
        public ApplicationViewModel MainViewModel
        {
            get { return (ApplicationViewModel)App.Current.MainWindow.DataContext; }
        }
        /// <summary>
        /// Viewmodel is unloaded
        /// </summary>
        void IViewModelInterface.Reset()
        {
            ResetData(CommandTags.Reset, true);
        }
    }
