        public class BillDetailsModel : INotifyPropertyChanged
        {
          // INSERT YOUR MODEL PROPERTIES
        /// <summary>
        ///     DEFAULT CONSTRUCTOR
        /// </summary>
        public BillDetailsModel()
        {
        }
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
