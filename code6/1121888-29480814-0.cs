    private void editMemo_Click(object sender, EventArgs e)
    {
        if(listBox1.SelectedItem != null)
        {
            BindingList<memo> bl = listBox1.DataSource as BindingList<memo>;
            bl.Remove(listBox1.SelectedItem as memo) ;
        }
    }
    
