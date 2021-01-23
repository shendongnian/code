    string projectnames = "";
    for (int i = 0; i < ListBox2.Items.Count; i++)
    {
    
        if (ListBox2.Items[i].Selected)
        {
           projectnames += ListBox2.Items[i].ToString() + ", ";
        }
    
     }
