     private void textBox1_TextChanged(object sender, EventArgs e)
            {
        
                listBox1.SelectedItems.Clear();
        
                for (i = 0; i < listBox1.Items.Count; i++)
                {
                    if (string.Equals(listBox1.Items[i].ToString(), textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        listBox1.SetSelected(i, true);
                    }
                }
        
            }
