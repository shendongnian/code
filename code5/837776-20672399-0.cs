    protected void SelectID(){
        var indexOfMatchedItem = -1;
        
        //Seen I'm using Listview DataContext bound with database.
        foreach (DataRow dtrCurrentRow in (((System.Data.DataView)CategoriesListView.ItemsSource)).Table.Rows)
        {
            //Retrieve the each row the first column
            String value = dtrCurrentRow[0].ToString().TrimEnd();
            
            //Try & match:True or False
            if (value.Equals(Last_CID))
            {
                //I can enter here already:
                MessageBox.Show("HI");
                                          //This shoud be the index of the item which match the "value" string                      
                     indexOfMatchedItem = CategoriesListView.Items.IndexOf(value);
                     break;
       
            }
        }
        //I try to see whether the indexOfMatchedItem is pointing to the correct position in the list of the index.
        MessageBox.Show("" + indexOfMatchedItem);
        //But at the end it still pointing to -1
        //That's why I cannot enter the below code:
       
        if (indexOfMatchedItem != -1)
        {
            CategoriesListView.SelectedItems.Clear();
            CategoriesListView.SelectedIndex = indexOfMatchedItem;
        }   
             
        }
