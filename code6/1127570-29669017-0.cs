    public Form1()
    {
         db.MdfConnectionString = ConfigurationManager.ConnectionStrings["MDFConnection"].ConnectionString;
         InitializeComponent();
    }
