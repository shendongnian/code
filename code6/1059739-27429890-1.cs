    public Window1()
    {
       InitializeComponent();
    } 
    public Window1(string x):base()
    {
        if(x == "a") this.TBOcena.Visibility = System.Windows.Visibility.Visible;
    }
