    using (OleDbConnection myCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=timetabledata.accdb"))
    {                       
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandType = CommandType.Text;
        string q = "INSERT INTO timehourly (teacheridh,subjectidh) Values (@teacherID,@subjid)" + " WHERE hour=@i AND dayid=@ds";
        cmd.CommandText = q;
        cmd.Parameters.AddWithValue("@teacherID", Convert.ToInt32(teacher_combo.SelectedValue).ToString());
        cmd.Parameters.AddWithValue("@subjid",  Convert.ToInt32(subject_combo.SelectedValue).ToString());
        cmd.Parameters.AddWithValue("@i",i.ToString());
        cmd.Parameters.AddWithValue("@ds",ds.Tables[0].Rows[k].ItemArray[0].ToString());
        
        cmd.Connection = myCon;
        myCon.Open();
        cmd.ExecuteNonQuery();
        System.Windows.Forms.MessageBox.Show("successfully added", "Caption",        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
    } 
