    try
    {
        MySqlCommand command = new MySqlCommand("update inventario SET can = can - " + numericUpDown1.Value + " WHERE cla = '" + comboBox1.Text + "';", conn);
        command.ExecuteNonQuery();
        j++;
        MySqlCommand command = new MySqlCommand("update inventario SET lin = 'CMI', dias = 0 WHERE cla = '" + comboBox1.Text + "';", conn);
        command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: No se puede modificar el inventario.");
        MessageBox.Show(ex.Message);
    }
