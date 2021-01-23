        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i>= 0; i--)
            {
                int item = Convert.ToInt32(listBox1.Items[i]);
                if (listBox2.Items.Contains(item))
                {
                    listBox1.Items.Remove(item);
                }
            }
        }
