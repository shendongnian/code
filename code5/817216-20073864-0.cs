    SqlDataReader myReader = null;
    SqlCommand myCommand = new SqlCommand("select BillNumber from BillData", cn);
    cn.Open();
    myReader = myCommand.ExecuteReader();
    myReader.Read();
    MessageBox.Show(myReader["BillNumber"].ToString());
    cn.Close();
