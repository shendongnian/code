    public string SerialNo
    {
        get { return serialNo; } 
        set
        {
            serialNo = value;
            NotifyPropertyChanged("SerialNo");
            // Update new property
            IsQtyReadOnly = serialNo == "The read only value";
        }
    }
    public bool IsQtyReadOnly // <<< New property
    {
        get { return isQtyReadOnly; } 
        set { isQtyReadOnly= value; NotifyPropertyChanged("IsQtyReadOnly"); }
    }
