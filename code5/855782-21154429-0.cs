    private void Form1_Load(object sender, EventArgs e)
       {
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand cmd = new OleDbCommand("select project_name, ID from tb_project", con);
        con.Open();
        OleDbDataReader DR = cmd.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(DR);
        
        //begin adding line
        DataRow row = table.NewRow();
        row["project_name"] = "Select Project Name";
        row["ID"] = 0;
        table.Rows.InsertAt(row, 0);
        //end adding line
        combo_status.DataSource = table;
        combo_status.DisplayMember = "project_name";
        combo_status.ValueMember = "ID";
        combo_status.Text = "Select Project Name";
    }
    private void btnSave_Click_Click(object sender, EventArgs e)
    {
        if(combo_status.SelectedValue == 0)
        {
             return; //do nothing if user didn't select anything in combobox, you can change this line of code with whatever process you want
        }
        OleDbConnection con = new OleDbConnection(constr);
        con.Open();
        OleDbCommand cmd = new OleDbCommand("Insert Into tb1(name) Values (@name)", con);
        cmd.Parameters.AddWithValue("name", combo_status.SelectedValue);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Inserted sucessfully");
    }
