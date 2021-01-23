    protected void ddlstudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstudents.SelectedIndex > 0)
        {
            BindData();
        }
    }
    
    private void BindData()
    {
        try
        {
            SQLiteConnection con = new SQLiteConnection("data source=C:\\ITS Database\\its.development.sqlite3");
    
            string strquery = "select topics.name,course_coverages.progress from topics JOIN course_coverages on topics.id=course_coverages.topic_id where course_coverages.student_id=@studentid AND course_coverages.course_id=@courseid";
    
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.connection=con;
            cmd = con.CreateCommand();
            cmd.CommandText = strquery;
    
            cmd.Parameters.AddWithValue("@studentid", ddlstudents.SelectedValue);
            cmd.Parameters.AddWithValue("@courseid", ddlcourse.SelectedValue);
    
            SQLiteDataAdapter ada = new SQLiteDataAdapter(cmd.CommandText, con);
    
            SQLiteCommandBuilder cbl = new SQLiteCommandBuilder(ada);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
    
        catch (SQLiteException)
        {
    
        }
    }
