      private int searchType()
            {
                int i = 0;
                if (dbtype.InvokeRequired)
                {
                    
                    dttypeDelegate dt = new dttypeDelegate(searchType);
                    i = (int)this.Invoke(dt);
                    return i;
                }
                else
                {
                   return i = dbtype.SelectedIndex; 
                }
    
             
                
            }
