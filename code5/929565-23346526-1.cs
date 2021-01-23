    private String mytext;
    public String myText
    {
       get { return myText; }
       set 
     { 
       mytext = value;
       NotifyPropertyChanged("myText"); 
     }
    }
