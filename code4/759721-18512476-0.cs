    List<CustomerDetails> customerDetails = new List<CustomerDetails>();
        List<CustomerDetails> MyCollection
        {
            get
            {
                return myList;
            }
            set
            {
                myList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyCollection"));
            }
        }
