    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(_loaded)
        {
            var result = MessageBox.Show("Do you want to save your changes?", "Save", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Save(false);
            }
        }
    }
