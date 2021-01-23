      for (int i = 0; i < listView1.Items.Count; i++)
        {
        if (listView1.Items[i].Selected)
          {
            string var1 = listView1.Items[i].ToString();  // <-------
            string var2 = var1.Substring(31, 5); 
            ... // code for other actions
            listView1.Items[i].Remove();
            i--;
          }
        }
