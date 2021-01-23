            int count = 0;
            foreach (var control in this.Controls)
            {
                if (control is CheckBox)
                {
                    if (((CheckBox)control).Checked)
                    {
                        count++;
                    }
                }
            }
            MessageBox.Show("Count: " + count);
