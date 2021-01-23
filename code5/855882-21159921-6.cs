    private void combo_cust_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection(constr);
    
        con.Open();
    
        string customerName = "";
        if (combo_cust_name.SelectedValue.GetType() == typeof(DataRowView))
        {
            DataRowView selectedRow = (DataRowView)combo_cust_name.SelectedValue;
            customerName = selectedRow["customer_name"].ToString();
        }
        else
        {
            customerName = combo_cust_name.SelectedValue.ToString();
        }
    
        string Sql2 = "SELECT customer_number FROM tb_customer WHERE customer_name = '" + customerName + "'";
        OleDbCommand cmd_type = new OleDbCommand(Sql2, con);
    
        OleDbDataReader DR_two = cmd_type.ExecuteReader();
        DataTable table_two = new DataTable();
        table_two.Load(DR_two);
    
        DataRow row_two = table_two.NewRow();
        row_two["customer_number"] = "Select Customer Number";
        table_two.Rows.InsertAt(row_two, 0); 
    
        comboBox2.DataSource = table_two;
        comboBox2.DisplayMember = "customer_number";
        comboBox2.ValueMember = "customer_number";
        comboBox2.Text = "Select Customer Number"; 
    }
