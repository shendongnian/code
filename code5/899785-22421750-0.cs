    private void button5_Click(object sender, EventArgs e)
    {
        string conString = "datasource=localhost;port=3306;username=root;password=";
        string cmdText = "Insert INTO filmi.film (film) VALUES (@film)";
        using(MySqlConnection dataConnection = new MySqlConnection(conString))
        using(MySqlCommand dataCommand = new MySqlCommand(cmdText, dataConnection))
        {
             try
             {
                dataConnection.Open();
                dataCommand.Parameters.AddWithValue("@film", this.tB_Dodaj.Text);
                // If ExecuteNonQuery returns a value > 0 then your record has been inserted
                // Just add the name of the film to the two combos 
                if(dataCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("You added a new movie!");
                    comboBox1.Items.Add(this.tB_Dodaj.Text);
                    comboBox2.Items.Add(this.tB_Dodaj.Text);
                }
             }
             catch(Exception ex)
             {
                MessageBox.Show("Fail to add a new movie! " + ex.Message);
             }
        }
    }
