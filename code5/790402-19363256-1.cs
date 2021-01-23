    protected void btnformatric_Click(object sender, EventArgs e)
    {
        int rowIndex = 0;
        if (int.TryParse(hdnRowIndex.Value, out rowIndex))
        {
            //Get the row
            GridViewRow row = gvDoctorList.Rows[rowIndex];            
            Button btn = (Button)row.FindControl("Select");
    
            if (btn != null)
            {
    
                string pIDstr = Convert.ToString(Session["PatientId"]);
                string exam = ((Button)sender).Text;
    
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[PatExam]([PId],[Exam]) VALUES (@pid,@exam)", con);
    
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@pid", pIDstr);
                    cmd.Parameters.AddWithValue("@exam", exam);
    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("Error Occured: " + ex.Message.ToString());
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                }
            }
        }
    }
              
