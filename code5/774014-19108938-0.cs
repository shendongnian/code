    try
    {
        object Name = cmd.ExecuteNonQuery();
        MessageBox.Show("Client details are inserted successfully");
        txtName.Clear();
        txtContactPerson.Clear();
        BindData();
    }
    catch(Exception ex)
    {
        //Handle exception, Inform User
    }
    finally
    {
        con.Close();
    }      
  
