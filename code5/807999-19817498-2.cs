    protected void Button4_Click(object sender, EventArgs e)
            {
                if (ListBox1.SelectedIndex != -1)
                {
                    ListBox1.Items.Remove(ListBox1.SelectedItem);
                }
                if (ListBox2.SelectedIndex != -1)
                {
                    ListBox2.Items.Remove(ListBox2.SelectedItem);
                }
                if (ListBox3.SelectedIndex != -1)
                {
                    ListBox3.Items.Remove(ListBox3.SelectedItem);
                }
            }
