    try
    {
        using (SqlConnection cn = new SqlConnection(global::ProjectAssessment.Properties.Settings.Default.Database1ConnectionString))
        using (SqlCommand exesql = new SqlCommand(@"INSERT INTO Students (Student_Id,Student_name,Unit_number,Unit_grade) values(@studentID, @studentName, @unitNumber, @unitGrade)", cn))
        {
            exesql.Parameters.Add("@studentID", SqlDbType.Int).Value = textBox1.Text;
            exesql.Parameters.Add("@studentName", SqlDbType.VarChar).Value = textBox2.Text;
            //... and others
            cn.Open();
            exesql.ExecuteNonQuery();
        }
        MessageBox.Show("Student record added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.studentsTableAdapter.Fill(this.database1DataSet.Students);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
