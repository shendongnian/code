    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string queryCity(string id)
    {
        DataSet ds = new DataSet();
        DataTable dt= new DataTable("Table");
        SqlConnection MRK_Conn = new SqlConnection(@"Data Source=KEVAL;Initial Catalog=SampleDatabase;Persist Security info=True;User ID=sa;Password=sa123");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sql_dr;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        MRK_Conn.Open();
        cmd = new SqlCommand("select [City RowID], [City Description] from City where [Des Ref Province] = '" + id + "'", MRK_Conn);
        dt = new DataTable();
        sql_dr = cmd.ExecuteReader();
        dt.Load(sql_dr);
        sql_dr.Close();
        MRK_Conn.Close();
        ds.Tables.Add(dt);
        return ds.GetXml();
    }
