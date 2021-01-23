        private void Item_Clicked(object sender, EventArgs e)
        {
            string item = listBox.SelectedItem.ToString() ; 
            list_name = list_name.Where(x=>
                                                       {
                                                          if(x != item)
                                                          return true ; 
                                                          else
                                                          return false ; 
                                                       }.ToList() ; 
           listBox.DataSource = null ; 
           listBox.DataSource = list_name;
           // listBox is the name of your `ListBox`.
            // list_name is your original list.
       } 
