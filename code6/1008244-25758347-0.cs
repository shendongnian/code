    using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
        {
            string stR = @"DECLARE @listStr VARCHAR(500); select @listStr = COALESCE(@listStr + ';' ,'') + eml_ID from EmailGroup where eml_Level=3 and eml_Stat=1";
            using (SqlCommand cmD = new SqlCommand(stR, sqlConn))
            {
              // Omitted
