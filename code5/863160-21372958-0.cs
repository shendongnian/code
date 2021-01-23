     private void checkBoxCheckedChanged(object sender, EventArgs e)
            {
                CheckBox cb = sender as CheckBox;
                if (cb != null)
                    if (cb.Checked) listBox1.Items.Add(cb.Text); else listBox1.Items.Remove(cb.Text);
            }
