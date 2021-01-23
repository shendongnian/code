     string str = GetValue(9).ToString().TrimEnd(':');
     string[] strList = str.Split(':');
   
     foreach (string s in strList)
            {
                foreach (ListItem item in chkTopics.Items)
                {
                    if (item.Value == s)
                    {
                        item.Selected = true;
                        break;
                    }
                
                }
    
            }
