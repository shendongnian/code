    private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {   
           System.Collections.IList pathRemove;
           pathRemove = lstPerson.SelectedItems;
           
           if(pathRemove.Count != 0)
              {
                   for (int i = pathRemove.Count - 1; i >= 0; i--)
                        {
                            lstPerson.Remove((Person)pathRemove[i]);//multiple deletes
                        } 
             }
        
           
        } 
