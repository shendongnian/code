    try
    {
        string str = "SELECT * FROM Students WHERE Student_Id = @id AND " +
                     "Unit_number LIKE @search";
        connect.Open();
        SqlCommand command = new SqlCommand(str, connect);
        command.Parameters.Add("id", SqlDbType.NVarChar).Value = 
            textBox1.Text;
        command.Parameters.Add("search", SqlDbType.NVarChar).Value = 
            "%" + textBox2.Text + "%";
        
        SqlDataAdapter dataAdapt = new SqlDataAdapter();
        dataAdapt.SelectCommand = command;
        DataTable dataTable = new DataTable();
        dataAdapt.Fill(dataTable);
        // At this point you should have a DataTable with some results in it.
        // This is not going to be the best way of displaying data, 
        //  but it should show you _something_
        // It just iterates through the rows showing the columns 
        //  which you've shown as being in your data.
        
        foreach (DataRow dr in dataTable.Rows)
        {
            MessageBox.Show(String.Format("{0} - {1} - {2} - {3}", 
                            dr["Student_Id"], dr["Student_name"],
                            dr["Unit_number"], dr["Unit_grade"]));
        }
        connect.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
