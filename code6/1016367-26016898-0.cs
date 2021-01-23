     private void button1_Click(object sender, EventArgs e)
        {
            string name;
            name = listBox1.SelectedItem.ToString();
            listBox2.Items.Add(name);
            listBox1.Items.Remove(listBox1.SelectedItem);
            if(0>=listBox1.Items.Count)
            {
                button1.enabled = false;
            }
        }
