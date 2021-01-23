    con.Open();
    SqlCommand command = new SqlCommand("GetDates", con);
    command.CommandType = CommandType.StoredProcedure;
    DataTable dt = new DataTable();
    dt.Load(command.ExecuteReader());
    day.DataSource = dt;
    day.DataTextField = "Hours";
    day.DataValueField = "Dates";
    day.DataBind();
