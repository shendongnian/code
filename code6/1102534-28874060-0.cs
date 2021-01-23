    private void selectEmployee(int idAdministration)
    {
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
        SqlCommand Cmd = new SqlCommand("SELECT * FROM Employee WHERE IdAdministration = @idAdministration", con);
        Cmd.Parameters.AddWithValue("@idAdministration", idAdministration);
        DataTable Dt = new DataTable();
        Dt.Load(Cmd.ExecuteReader());
        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.CurrentRow.Cells["Employee"];
        cb.Value = null; //add this
        cb.DataSource = Dt;
        cb.DisplayMember = "Name";
        cb.ValueMember = "CodeEmployee";
        con.Close();
    }
