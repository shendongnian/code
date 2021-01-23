    foreach (Control item in ModuleTab.Controls)
    {
      if (item.GetType() == typeof(CheckedListBox)))
       {
        for (int i = 0; i < item.Items.Count; i++)
            {
             item.SetItemChecked(i, false);
            }
       }
    }
 
