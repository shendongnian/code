    public class KeyTable
    {
       public int Id { get; set; }
       // whatever data you need
    
       public static List<KeyTable> GetKeyTables
       {
          DataSet ds = new DataSet();
          ds = SqlDBHelper.ExecuteMultiSelectCommand(
                   "Sp_Get_Key_Tables",
                   CommandType.StoredProcedure);
          
          foreach (var dr in ds.Tables[0].Rows)
          {
              // build the POCOs using the DataSet
          }
       } 
    }
