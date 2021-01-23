    string query = @"SELECT StudentInfoId, Name, Age, State, tbl2.ClassName 
                     FROM   tblstudentinfo tbl1 
                     INNER JOIN Class tbl2 ON (tbl1.class = tbl2.classid)
                     WHERE (@name IS NULL OR name = @name)
                     AND   (@age IS NULL OR age = @age)
                     AND   (@state IS NULL OR state = @state)
                     AND   (@classes IS NULL OR classes = @classes)";
    DataTable table = new DataTable();
    using(var conn = new SqlConnection(" ... "))
    using(var da = new SqlDataAdapter(query, conn))
    {
        var parameters = da.SelectCommand.Parameters;
        var p = new SqlParameter("@name", SqlDbType.NVarChar);
        if(!string.IsNullOrWhiteSpace(this.name.Text))
            p.Value = this.name.Text.Trim();
        else
            p.Value = DBNull.Value;
        parameters.Add(p);
        p = new SqlParameter("@name", SqlDbType.Int);
        int age;
        if(int.TryParse(this.age.Text, out age))
            p.Value = age;
        else
            p.Value = DBNull.Value;
        parameters.Add(p);
        // ...
        da.Fill(table);
    }
    GridView1.DataSource = table;
    GridView1.DataBind();
