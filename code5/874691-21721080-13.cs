        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Record")
            {
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if ((ctrl.GetType() == typeof(TextBox)) ||
                       (ctrl.GetType() == typeof(ComboBox)) ||
                       (ctrl.GetType() == typeof(CheckBox)))
                    {
                        ctrl.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if ((ctrl.GetType() == typeof(TextBox)) ||
                       (ctrl.GetType() == typeof(ComboBox)) ||
                       (ctrl.GetType() == typeof(CheckBox)))
                    {
                        ctrl.Enabled = true;
                    }
                }
            }
        }
