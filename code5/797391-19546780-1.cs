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
            get { return "sbcvsj "; }
        }
        /// <summary>
        /// Will be called for each and every property when ever it's value is changed
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
        private string Validate(string properyName)
        {
            //Retun error message if there is error on else return empty or null string
            string validationMessgae = string.Empty;
            switch (properyName)
            {
                case "Name"://property name
                    //Valdiation contion
                    validationMessgae = "Error";
                    break;
            }
            return validationMessgae;
        }
    }
