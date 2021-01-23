    public int EmpRegistration(string username, string password, int isactive)
    { 
       try
       {
         //...
         using (SqlConnection connection = new SqlConnection(cs))
         {
              //...            
              return Convert.ToInt32(com.ExecuteScalar());                
         }
       }
       catch{ return -1; }       
     }
 
