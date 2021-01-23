    private void sID_textBox7_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView4.DataSource;
                bs.Filter = "[Product ID]=" + "'" + sID_textBox7.Text + "'";
                dataGridView1.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
