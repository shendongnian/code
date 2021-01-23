    if (List2.SelectedItem != null 
      if (! List1.Items.Contains(List2.SelectedItem))
         {  List1.Items.Add(List2.SelectedItem);
            List2.Remove(List2.SelectedItem);
         }
