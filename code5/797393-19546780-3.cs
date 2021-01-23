    class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string m_Name = "Type Here";
        public ViewModel()
        {
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Error
        {
            get { return "...."; }
        }
        /// <summary>
        /// Will be called for each and every property when ever its value is changed
        /// </summary>
        /// <param name="columnName">Name of the property whose value is changed</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get 
            {
                return Validate(columnName);
            }
        }
        private string Validate(string propertyName)
        {
            // Return error message if there is error on else return empty or null string
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "Name": // property name
                    // TODO: Check validiation condition
                    validationMessage = "Error";
                    break;
            }
            return validationMessage;
        }
    }
