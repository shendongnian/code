    list.BeginUpdate ();
    
    for(int i = 0; i < list.Items.Count; i++)
    {
       list.Items[i].SubItem[3].Text = "";
    }
    
    list.EndUpdate ();
