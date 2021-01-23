    private MyModel myModel;
	    public MyModel MyModel
	    {
		    get { return myModel;}
		    set { myModel = value;
                NotifyPropertyChanged("MyModel");
            }
	    }
