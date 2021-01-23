    private void dtTmPkrWtr_ValueChanged(object sender, EventArgs e)
    {            
           LoadGridData(dateTimePicker1.Value);
    }
    private void btnDisplay_Click(object sender, EventArgs e)
    {            
           LoadGridData(DateTime.Now);     
    }
    private void LoadGridData(DateTime selectedDate)
    {
        String query = "SELECT sno,currDate,WtrNm,Type,No FROM WtrTblAllot WHERE currDate = @SelectedDate";
        SqlCommand command = new SqlCommand(query, con);
        command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value);
        SqlDataAdapter da = new SqlDataAdapter(command);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dgvWtrAllot.DataSource = ds.Tables[0];
    }
