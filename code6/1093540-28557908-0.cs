    public Form1()
    {
        InitializeComponent();
        localhost = "blah ..."; // initialize this string
        myconnectionstring = "Server=" + localhost + "; Database=amepos2015; Uid=root; Pwd=fatehshah";  
        labelget();
    }
    string localhost = null;
    string myconnectionstring = null;
