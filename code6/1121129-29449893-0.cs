       for (int i = task.SelectedItems.Count - 1; i >= 0; i++)
       {
         if (task.Items[i].Selected)
         {
             task.Items.Remove(listView2.Items[i]);
         }
       }
