    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                DataTable tempTable = dataset.Tables[0];
                foreach (DataRow row in tempTable.Rows)
                {
                    if (row[0].ToString() == comboBox1.SelectedItem.ToString())
                    {
                        label1.Text = row[1].ToString();
                        label2.Text = row[2].ToString();
                        label3.Text = row[3].ToString();
                        label4.Text = row[4].ToString();
                        label5.Text = row[5].ToString();
                        label6.Text = row[6].ToString();
                    }
                }
            }
    }
