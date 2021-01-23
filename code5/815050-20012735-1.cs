    public void showCourse()
    {
        SqlCommand com = new SqlCommand("SELECT [Course_ID],[Course_Name],[Course_Type],[Course_Hours],[Course_Duration],[Course_Place],[Trainer_ID],[Volunteers] FROM [VolunteersAffairs].[dbo].[Course_Info]", con);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet dats = new DataSet();
        da.SelectCommand = com;
        da.Fill(dats, "Course_Info");
        
        if(dataGridViewShowCourse.Columns["MyButton"] == null){
          var col = new DataGridViewButtonColumn();
          col.UseColumnTextForButtonValue = true;
          col.Text = "ADD";
          col.Name = "MyButton";
          col.DataPropertyName = "Volunteers"; //<-- this is very important
          dataGridViewShowCourse.Columns.Add(col);
        }
        dataGridViewShowCourse.DataSource = dats.Tables["Course_Info"];
    }
