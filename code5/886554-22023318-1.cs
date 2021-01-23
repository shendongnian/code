    private void button5_Click(object sender, EventArgs e)
    {
    	Car c = (Car)listBox1.SelectedItem;
    	if (c == null)
    		return;
    			
    	if (!Double.TryParse(textBox8.Text, out c.Speed))
    		return;
    	int idx = listBox1.Items.IndexOf(listBox1.SelectedItem);
    	listBox1.Items.Remove(listBox1.SelectedItem);
    	listBox1.Items.Insert(idx, c);
    }
