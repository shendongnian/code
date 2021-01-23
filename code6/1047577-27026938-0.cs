    private void AvailableMin_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (AvailableMin.Text == "")
                {
                    textBox2.Visible = true;
                    textBox2.Text = "There are no to dates available for this particular user";
                }
                else
                {
                    textBox2.Visible = false;
                }
            }
    
            private void AvailableMax_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (AvailableMax.Text == "")
                {
                    textBox1.Visible = true;
                    textBox1.Text = "There are no to dates available for this particular user";
                }
                else
                {
                    textBox1.Visible = false;
                }
            }
