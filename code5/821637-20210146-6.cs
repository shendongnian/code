    private void Listview1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if(e.Item.Checked){
          listView1.Items.Remove(e.Item);
          listView2.Items.Add(e.Item);      
        }
    }
