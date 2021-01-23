    int iResult = cmd.ExecuteNonQuery();
    con.Close();
    
    if(iResult > 0)
       MessageBox.Show("Successfully saved ", "Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
    else
       MessageBox.Show("Record not saved ", "Company", MessageBoxButtons.OK, MessageBoxIcon.Error);
