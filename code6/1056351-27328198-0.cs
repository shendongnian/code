    private void button3_Click(object sender, EventArgs e) //ISBN Search Button
    {
        checkedListBox2.Items.Clear();
        foreach (var pair in library)
        {
            if (pair.Key.Contains(textBox1.Text))
            {
                checkedListBox2.Items.Add(pair.Value);
            }
        }  
    }
