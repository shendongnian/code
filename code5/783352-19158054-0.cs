    protected void Btn_log(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
    
            ds = obj.selectlogin("", TextBox1.Text, TextBox2.Text,"login");
        bool hasRows = ds.Tables.Cast<DataTable>()
                                   .Any(table => table.Rows.Count != 0);
            if (hasRows)
            {
                Response.Redirect("dashboard.aspx");
            }
    
        }
