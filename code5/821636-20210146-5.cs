    for(int i = listView1.Items.Count-1; i >= 0; i--){
       var item = listView1.Items[i];
       if(item.Checked) {
          listView1.Items.Remove(item);
          listView2.Items.Add(item);
       }
    }
