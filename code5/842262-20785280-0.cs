    public ActionResult Index()
    {
        connection connect = new connection();
        string query = "SELECT Event_Name FROM tbl_Event WHERE Event_ID=2";
        return View(connect.SelectRecord(query));
    }
    internal DataTable SelectRecord(string query)
    {
            try
            {
                OpenConnection();
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
                CloseConnection();
            }
    }
