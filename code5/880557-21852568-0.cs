    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        SqlConnection con = new SqlConnection(@"***my connection string***");
        con.Open();
        SqlCommand cmnd = con.CreateCommand();
        cmnd.CommandType = CommandType.Text;
        //Changed code here
        cmnd.CommandText = "SELECT TOP 1 * FROM tblTicketDetail where LOWER(name) = LOWER('" + textBox1.Text + "')";
        SqlDataReader dReader;
        dReader = cmnd.ExecuteReader();
        if (dReader.Read())
        {
            while (dReader.Read())
            {
                namesCollection.Add(dReader["ContactPerson"].ToString());
                //Added code here
                textBox2.Text = dReader["Number"].ToString();
                textBox3.Text = dReader["email"].ToString();
            }
        }
        else
        {
            MessageBox.Show("Data not found");
        }
        dReader.Close();
        textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        textBox1.AutoCompleteCustomSource = namesCollection;
    }
