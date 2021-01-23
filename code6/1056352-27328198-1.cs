    private void button3_Click(object sender, EventArgs e) //ISBN Search Button
    {
        checkedListBox2.Items.Clear(); //clears list on click
        foreach (var pair in library)
        {
            if (pair.Key.Contains(textBox1.Text))
            {
                checkedListBox2.Items.Add(pair.Value);
            }
        }  
    }
