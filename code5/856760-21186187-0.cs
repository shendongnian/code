    using System.Data.SQLClient;
    
    Class DataExtract
    { 
    
    Public DataTable Extract()
      {
         SqlConnection con = new SqlConnection("Data Source = .;
                                           Initial Catalog = domain;
                                           Integrated Security = True");
         con.Open();
         SqlCommand cmd = new SqlCommand("Select * from tablename", con); 
    
         Return new DataTable().load(cmd.ExecuteReader());
    
      }
    }
