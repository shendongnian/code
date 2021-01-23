        public class Phone : IDataErrorInfo, INotifyPropertyChanged
    {
        string areaCode;
        public string AreaCode
        {
            get
            {
                return areaCode; 
            }
            set
            {
                if (areaCode != value)
                {
                    areaCode = value;
                    ValidateProperty("AreaCode"); //Validate on PropertyChanged
                    Notify("AreaCode");
                }
            }
        }
        short? phoneTypeId;
        public short? PhoneTypeID
        {
            get
            {
                return phoneTypeId;
            }
            set
            {
                if (phoneTypeId != value)
                {
                    phoneTypeId = value;
                    ValidateProperty("PhoneTypeID");
                    Notify("PhoneTypeID");
                }
            }
        }
        long? phoneNumber;
        public long? PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    ValidateProperty("PhoneNumber");
                    Notify("PhoneNumber");
                }
            }
        }
        string extensionNumber;
        public string ExtensionNumber
        {
            get
            {
                return extensionNumber;
            }
            set
            {
                if (extensionNumber != value)
                    extensionNumber = value; Notify("ExtensionNumber");
            }
        }
        public string Error { get { return null; } }
        Dictionary<string, string> errors = new Dictionary<string, string>();
        public string this[string columnName]
        {
            get
            {
                if(errors.ContainsKey(columnName)
                    return errors[columnName];
                return null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        //This could be much more generic but for simplicity 
        void ValidateProperty(string propertyName)
        {
            if (propertyName=="AreaCode" && string.IsNullOrWhiteSpace(AreaCode))
                    errors.Add(propertyName,"AreaCode is Mandatory");
            else if (propertyName == "PhoneNumber" && !PhoneNumber.HasValue)
                    errors.Add(propertyName, "PhoneNumber can not be null");
            else if(propertyName == "PhoneTypeID" && !PhoneTypeID.HasValue)
                errors.Add(propertyName, "PhoneTypeID can not be null");
            
            else if(errors.ContainsKey(propertyName))
                errors.Remove(propertyName);
        }
        public void ValidatePhoneObject()
        {
            ValidateProperty("AreaCode");
            ValidateProperty("PhoneNumber");
            ValidateProperty("PhoneTypeID");
            //Must fire property changed so that binding validation System calls IDataErrorInfo indexer
            Notify("AreaCode");
            Notify("PhoneNumber");
            Notify("PhoneTypeID");
        }
    }
