    public void GetProduct(ListBox MyListBox)
    {
        
        MyListBox.Sorted = true;
        MyListBox.Items.Add("aaaaa");
    }
    private void button2_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        GetProduct(listBox1);
    }
