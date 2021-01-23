    bindingSource.Filter = "columnname = 'value'";
    
    private void button1_Click(object sender, EventArgs e)
    {
        string searchValue = textBox1.Text;
    
         dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         bindingSource.Filter = string.Format("{0} = '{1}'","YourColumnName", searchValue );
         //here you can do selection if you need
    }
    
    To remove filter use the following
    
    bindingSource.RemoveFilter();
    //or
    bindingSource.Filter = null;
