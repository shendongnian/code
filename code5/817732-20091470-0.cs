        public partial class _service : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public static string binddata(yourObject yourDatabaseObject)//tbl_BI_mant[]
            {
                //connect to Database 
                //and add your Date filter
              return  Data.getpictureWithDateFilter(yourDatabaseObject.datefilter) 
            }
    }
