    //Form 2 constructor  
    
    public Form2(MainForm mainForm)
       {
        InitializeComponent();
       }
                
      
    
     public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
     public event UpdateDelegate UpdateEventHandler;
                
     
    
     public class UpdateEventArgs : EventArgs
        {
          public string Data { get; set; }
        }
            
      
    
    protected void InsertData()
        {
           UpdateEventArgs args = new UpdateEventArgs();
           UpdateEventHandler.Invoke(this, args);
        }
            
     
    
     private void btnInsertData_Click(object sender, EventArgs e)
         {
            SqlCommand cmd = new SqlCommand("SP_AddNewRow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", "Test1");
            cmd.Parameters.AddWithValue("@param2", "Test2");
                        
        if (con.State == ConnectionState.Closed)
           {
             con.Open();
            }
        int n = cmd.ExecuteNonQuery();
    
        con.Close();
    
        if (n != 0)
        {
          //your codes if needed
           InsertData();
        }
    }
