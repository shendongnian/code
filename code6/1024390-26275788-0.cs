    private Form2 _form2;
    private void button1_Click(object sender, EventArgs e)
    {
        _form2 = new Form2(this);
        _form2.Show();
    }
    public string ItemValue
    {
        get { return listBox1.SelectedItem.ToString(); }
    }
    public void SetSelectedItemValue(string value)
    {
        listBox1.Items[listBox1.SelectedIndex] = value;
    }
