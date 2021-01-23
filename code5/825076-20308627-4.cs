        private String getSelectedRadioButtonName()
         {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is RadioButton && ((RadioButton) c).Checked==true)
                    {
                        return c.Text;
                    }
                }
                return "No Game";
          }
        private void button1_Click(object sender, EventArgs e)
        {
           
                MessageBox.Show("You are playing "+getSelectedRadioButtonName());
        }
