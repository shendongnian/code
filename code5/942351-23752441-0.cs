        if (!IsPostBack)
        {
            //Label1.Text = Request.QueryString["Item"];
            //Label2.Text = Request.QueryString["Color"];
            //grid();
            var colourTable = new DataTable();
            colourTable.Columns.Add("Value", typeof(string));
            var colours = Request.QueryString["vaL1"].Split(',');
            for (int i = 0; i < colours.Length; i++)
            {
                var newRow = colourTable.NewRow();
                newRow[0] = colours[i];
                colourTable.Rows.Add(newRow);
            }
        }
        string sql = "SELECT * FROM lady_cloth WHERE color IN (SELECT Value FROM @Colours)";
        cmd = new SqlCommand(sql, con);
        DataSet ds3 = new DataSet();
        using (var adapter = new SqlDataAdapter(sql, con))
        {
            var parameter = new SqlParameter("@Colours", SqlDbType.Structured);
            //parameter.Value = colourTable;
            parameter.TypeName = "dbo.StringList";
            cmd.Parameters.Add(parameter);
            con.Open();
            adapter.Fill(ds3);
        }
        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds3;
            GridView1.DataBind();
        }
        else
        {
        } 
      
    }
