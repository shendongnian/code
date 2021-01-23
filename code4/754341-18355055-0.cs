     for (int i = listView1.Items.Count-1; i >=0 ; i--)
        {
        if (listView1.Items[i].Selected)
          {
            string var1 = listView1.SelectedItems[i].ToString(); //error
            string var2 = var1.Substring(31, 5); 
            ... // code for other actions
            listView1.Items[i].Remove();
    
          }
        }
