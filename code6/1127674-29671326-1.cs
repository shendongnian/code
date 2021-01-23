    string projectnames = "";
    bool firstValue = true;
    for (int i = 0; i < ListBox2.Items.Count; i++)
                {
                  
                    if (ListBox2.Items[i].Selected == true || ListBox2.Items.Count > 0)
                    {
                       if(!firstValue)
                       {
                          projectnames += ", " + ListBox2.Items[i].ToString();
                       }
                       else
                       {
                          projectnames += ListBox2.Items[i].ToString();
                          firstValue = false;
                       }
                       
                    }
        
                }
