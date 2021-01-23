      for (int i = 0; i < listView1.SelectedItems.Count; i++)
        {
            string var1 = listView1.SelectedItems[i].ToString();
            string var2 = var1.Substring(31, 5); 
            ... // code for other actions
            listView1.Items[i].Remove(); // possible error here as cant 
                                    //  modify list you are looking through 
                                    // (and I may not represent same item
            i--;
          }
        }
