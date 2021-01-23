    if (comboBox1.SelectedItem.ToString() == "master" && comboBox2.SelectedItem.ToString() == "master.sql")
    {
    oConnection.Open();
    ***SqlCommand SqlCmd = new SqlCommand();
    SqlCmd.CommandText = textentry;
    SqlCmd.Connection = oConnection;
    var output = SqlCmd.ExecuteNonQuery();***
    if (MessageBox.Show("Execute " + comboBox2.SelectedItem.ToString() + " in the database " + comboBox1.SelectedItem.ToString() + " ?", "Execute?", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
     if (!output.Equals(0))
        {
            try
            {
                MessageBox.Show(comboBox2.SelectedItem.ToString() + " executed successfully in " + comboBox1.SelectedItem.ToString() + " database");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Script Execution Failed,"+exc);
            }
        }
    }
    else
    {
        MessageBox.Show("Execution cancelled by the user");
    }
    else
    {
        MessageBox.Show("Either the database or the sql script file selected is wrong!!");
    }
