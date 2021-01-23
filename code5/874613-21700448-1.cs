    SqlConnection connection = new SqlConnection(strcon);
        connection.Open();
     SqlCommand command = new SqlCommand("b_timing", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@UserId", Session["userid"].ToString());
        command.Parameters.AddWithValue("@CourseName", coursename.SelectedValue);
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);
        dt.Columns.Add("timing", typeof(string), "st_time+' '+'To'+' '+ed_time");
        if (dt.Rows.Count > 0)
        {
            timing.DataSource = dt;
            timing.DataTextField = "timing";
            timing.DataValueField = "timing";
            timing.DataBind();
            timing.Items.Insert(0, new ListItem("Choose Batch Timing", "0"));
            timing.Visible = true;
            timing.Focus();
        }
