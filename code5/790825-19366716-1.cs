     public ArrayList List { get; set; }
            public MainWindow()
            {
                InitializeComponent();
    
                
                SqlDataReader rdr = cmd.ExecuteReader();
                List = new ArrayList();
                while (rdr.Read()){
                    List.Add(new { Id = rdr.GetString(1), Value = rdr.GetString(0)}); //this class will contain the same data schema in your datareader but using properties 
                }
                rdr.Close();
            }
