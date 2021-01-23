     private string GetDisplayMember(int tag)
        {
            string displayMember = string.Empty;
            if (tag != null)
            {
                switch (tag)
                {
                    case 0:
                        displayMember = "Revision";
                        break;
                    case 1:
                        displayMember = "Class";
                        break;
                    case 2:
                        displayMember = "Errordate";
                        break;
             }
          }
   
            return displayMember;
        }
        private void CheckedViewMenuItems(MenuClass m)
        {
            try
            {    
                if (m!=null)
	            {
                     
                    bool IsChecked = m.IsChecked;
                    if (IsChecked)
                    {                    
                       ColumnDescriptor cl1 =new   ColumnDescriptor     
                        {           
                           HeaderText =m.Header, 
                           DisplayMember= GetDisplayMember(m.Tag)
                         };
                           int idx = Convert.ToInt32(m.Tag);
                           int insertidx = Math.Min(idx,   
                           this.Columns.Count);
                           this.Columns.Insert(insertidx, cl1);
                    }
                    else
                    {
                        foreach (var item in this.Columns)
                        {
                            if (item.HeaderText == m.Header)
                            {
                               // item.DisplayMember = "";
                                this.Columns.Remove(item);  
                                break;
                            }
                        }
                    }            
		 
	            }              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("{0}{1}{2}{1}{3}", ex.GetType().ToString(), Environment.NewLine, ex.Message, ex.StackTrace));
                ErrorLogger.Log(LogLevel.Error, ex.ToString());
            }
     
