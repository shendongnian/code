     public ArrayList List { get; set; }
            public MainWindow()
            {
                InitializeComponent();
    
                
                SqlDataReader rdr = cmd.ExecuteReader();
                List = new ArrayList();
                while (rdr.Read()){
                    List.Add(new YourClass(rdr.GetString(1), rdr.GetString(0))); //this class will contain the same data schema in your datareader but using properties 
                }
                rdr.Close();
            }
