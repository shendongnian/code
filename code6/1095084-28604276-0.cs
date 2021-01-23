         public Add()
                {
                    InitializeComponent();
                    con.Open();
                }
    .........
     private void Add_Closing(object sender, EventArgs e)
           {
             con.Close();
           }
