    //default constructor calling the correct constructor with params.
    public frmProperties() :this(null,null) { }
    
    public frmProperties(Agent ac, PropertyCollection pcPassed)
    {
        InitializeComponent();
        if(ac != null) //check for null values
            curAgent = ac;
        else
            curAgent = new Agent();
        if(pcPassed != null)//check for null values
            pc= pcPassed;
        else
            pc = new PropertyCollection();  
    }
