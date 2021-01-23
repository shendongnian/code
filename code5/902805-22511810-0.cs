    public ActionResult TestView()
    {
    DataTable datatable = ReadStatus("yourconnectionstring");
    List<Status> statuses = DataTableToStatus(datatable);
    StatusModel model = new StatusModel();
    
    model.Statuses = statuses 
    return View(Statuses);
    }
    private DataTable ReadStatus(string connectionString) 
    { 
    SqlConnection conn = new SqlConnection(connectionString);
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = conn.CreateCommand(); 
    cmd.CommandText = @"SELECT * FROM Statuses"; 
    da.SelectCommand = cmd; 
    DataSet ds = new DataSet(); 
    conn.Open(); 
    da.Fill(ds); 
    conn.Close(); 
    return ds.Tables[0]; 
    } 
    
    private List<Status> DataTableToStatus(DataTable table) 
    { 
    for (int i = 0; i < table.Rows.Count; i++) 
    { 
    int id = (int)table.Rows[i].ItemArray[0];
    string desc = (string)table.Rows[i].ItemArray[1];
    statuses.Add(new Status(id, desc)); 
    } 
    
    return statuses; 
    }
