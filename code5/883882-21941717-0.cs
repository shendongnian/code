    private void btn_calculate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "AND" && valueOne.Text != "" || valueTwo.Text != "")
            {
                //SO This bit assumes everything has a value in
                if (valueOne.Text == "T" || valueOne.Text == "1" || valueTwo.Text == "T" || valueTwo.Text == "1)
                {
                        resOne.Text = "T";
                        resOne.BackColor = Color.LawnGreen;
                        resLineOne.BackColor = Color.LawnGreen;
                }
                else
                {
                    resOne.Text = "F";
                    resOne.BackColor = Color.Salmon;
                    resLineOne.BackColor = Color.Salmon;
                }
            }
            else if (valueOne.Text == "" || valueTwo.Text == "")
            {
                MessageBox.Show("Error: Empty Fields");
            }
        }
