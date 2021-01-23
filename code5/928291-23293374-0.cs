    Try this code. 
    public DataTable DataDownload(string question)
     {
           using (var ada = new SqlDataAdapter(question, DBconnection))
    		{    		    
    		    // Use DataAdapter to fill DataTable
    		    DataTable dt = new DataTable();
    		    ada.Fill(dt);
    			return dt;
    
    		    
    		}
      }
