    private void button1_Click(object sender, EventArgs e)
    {
        int index = checkedListBox1.Items.Add("test");
        checkedListBox1.SetItemCheckState(index, CheckState.Indeterminate);
    }
