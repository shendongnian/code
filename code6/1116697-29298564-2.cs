    public List<ColorAndMoreClass>> ListOfColorAndMore{ get; set; }
    
    public Window1() 
    { 
        ListOfColorAndMore = GetDataThatFillsUpTheProperty(); 
        InitializeComponent(); 
        DataContext = this;
    } 
