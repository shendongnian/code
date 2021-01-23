    private void fillGrid(string selectCmd)
    {
      List<string> Results = new List<string>();
      DataTable dt = cMethos.selectAtable(selectCmd);
      
      foreach(DataRow row in dt.Rows())
      {
         foreach (object rowObject in row.ItemArray)
         {
             Results.Add(rowObject.ToString());
         }
     
      }
    
      dgSend.DataSource = Results;
    
    
    }
