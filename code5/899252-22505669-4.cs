        private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=SERVER;" +
                                              "Initial Catalog=Partner_database;" +
                                              "Integrated Security=True");
        SqlCommand command = new SqlCommand("select * from [dbo].[Test_table]", con);
 
        sda = new SqlDataAdapter(command);
        sda.AcceptChangesDuringFill = true;
        sda.AcceptChangesDuringUpdate = true;
        set.Clear(); //just to make sure i have a clear set
        cmdBuilder = new SqlCommandBuilder(sda); //use the command builder to create the commands
        sda.Fill(set_date,"cucu1");
        dataGridView1.DataSource = set_date;
        dataGridView1.DataMember = "cucu1";
    }
 
