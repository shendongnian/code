     **Add a public property only public property can be participate in databinding**
       #region Public Properties
    
      private ObservableCollection<YourModel> _collectionofValue;
       
        public ObservableCollection<YourModel> CollectionofValues
        {
            get
            {
                return _collectionofValue;
            }
            set
            {
                _collectionofValue=value;
                raisepropertyChanged("CollectionofValues");
            }
        }
        
       private string _value;
        public string Value
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("Value");
            }
        }
        #endregion
       **Set value to this public property when you get value**
 
    // for single values
    public void getValue()
    {
      value =GetXmlValue(); // your method that will return the value;
    }
    //  as it is a collection 
     public void getValuestoCollection()
    {
       Collection.Add(new YourModel(value="SampleValue1");
     Collection.Add(new YourModel(value="SampleValue1");
     Collection.Add(new YourModel(value="SampleValue1");
      Collection.Add(new YourModel(value="SampleValue1");
    }
