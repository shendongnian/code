 
       public class ViewModel : IDataErrorInfo, INotifyPropertyChanged
        {
                private bool _requirePinNumber;
                public bool RequirePinNumber
                {
                    get
                    {
                        return this._requirePinNumber;
                    }
                    set
                    {
                        this._requirePinNumber = value;
                        if (this.PropertyChanged != null)
                        {
                            this.PropertyChanged(this, new PropertyChangedEventArgs("RequirePinNumber"));
                            this.PropertyChanged(this, new PropertyChangedEventArgs("PinNumber"));
                        }
                    }
                }
        
                private string _pinNumber;
                public string PinNumber 
                { 
                    get
                    {
                        return this._pinNumber;
                    }
                    set
                    {
                        this._pinNumber = value;
                        if (this.PropertyChanged != null)
                        {
                            this.PropertyChanged(this, new PropertyChangedEventArgs("PinNumber"));
                        }
                    }
                }
        
                public string Error
                {
                    get 
                    { 
                        throw new NotImplementedException(); 
                    }
                }
        
                public string this[string columnName]
                {
                    get 
                    {
                        if (columnName == "PinNumber") 
                        {
                            if (this.RequirePinNumber && string.IsNullOrEmpty(this.PinNumber))
                            {
                                return "PIN number cannot be blank.";
                            }
                        }
                        return string.Empty;
                    }
                }
        
                public event PropertyChangedEventHandler PropertyChanged;
            }
