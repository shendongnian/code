    var dt = new Datatable();
    using (var conn = new SqlConnection(""))
    using (var comm = new SqlCommand("sp_getData", conn))
    {
        conn.Open();
        using (var reader = comm.ExecuteReader())
        {
            dt.Load(reader);
        }
    }
    grdView.DataSource = dt;
