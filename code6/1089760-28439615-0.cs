    using (var connect = new OleDbConnection(coo))
    {
        using (OleDbCommand command = new OleDbCommand("SELECT * FROM Items where itemno = ?", connect))
        {
            command.Parameters.Add(new OleDbParameter("@p1", OleDbType.Integer)
            {
                Value = textBox1.Text
            });
            DataTable dt = new DataTable();
            OleDbDataAdapter ODA = new OleDbDataAdapter(command);
            ODA.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
