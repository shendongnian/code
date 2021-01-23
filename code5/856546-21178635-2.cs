    Try
    {
        OleDbConnection con = new OleDbConnection(constr);
        con.Open();
        string Sql_radio = ""; 
        if(RadioButton1.Checked)
        {
         Sql_radio = "Insert Into tb1(name)Values ('Yes')";
        }
        else if(RadioButton2.Checked)
        {
         Sql_radio = "Insert Into tb1(name)Values ('No')";
        }
        OleDbCommand cmd = new OleDbCommand(Sql_radio, con);
    
    
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Inserted sucessfully");
    }
    catch(Exception Ex)
    {
    MessageBox.Show(Ex.Message);
    }
