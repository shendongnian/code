    private int searchType()
            {
                int i = 0; 
                if (dbtype.InvokeRequired)
                {
                    dttypeDelegate dt = new dttypeDelegate(searchType);
                    this.Invoke(dt);   // <--- marshal to UI thread
                }
                else
                {
                    i = dbtype.SelectedIndex; 
                }
    
    
              i = dbtype.SelectedIndex; // <--- now we're back on the non-UI thread.
    
               return i;
            }
