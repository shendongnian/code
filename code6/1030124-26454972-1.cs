    public void click(object sender, EventArgs e)
    {
        if (this.bindingSource1.SelectedItem != null)
        {
             var dr = ((DataRowView)this.bindingSource1.SelectedItem).Row;
             dr.Item("IsSelected") == true;
             this.bindingSource1.EndEdit();
         }
    }
