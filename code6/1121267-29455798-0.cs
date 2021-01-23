    namespace DAL
    {
      public class Clarity_BLL
      {
        public int PURITY_ID { get; set; }
        public string PURITY_NAME { get; set; }
        public string PURITY_CODE { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public bool IDELETE { get; set; }
        public DataTable GET_CLARITYBYNAME()
        {
            ExceptionManager exManager;
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            DataTable dt = null;
            try
            {
                exManager.Process(() =>
                {
                    Database sqlDatabase = DBConnection.Connect();
                    DataSet ds = sqlDatabase.ExecuteDataSet("StoreProcedureName",PURITY_NAME_Para1, IDELETE_Para2);
                    dt = ds.Tables[0];
                }, "Policy");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
      }
     }
