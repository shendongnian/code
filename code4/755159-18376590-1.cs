         void fillGV()
            {
                DataTable UserAllocationTable = new DataTable();
                         
                UserAllocationTable.Columns.Add("Manager");
                UserAllocationTable.Columns.Add("AllocationPercentage");
                // go through listbox1 to find selected managers = selectedManagersList 
                List<string> selectedManagersListDates = new List<string>();
                int counterR = 0;
                foreach (ListItem strItem in ListBox1.Items)
                {                     
                        //selectedManagersListDates.Add(strItem.Value); 
                        DataRow drManagerName = UserAllocationTable.NewRow();
                        UserAllocationTable.Rows.Add(drManagerName);
                        UserAllocationTable.Rows[counterR]["Manager"] = strItem.Value;
                        counterR = counterR + 1;            
                }
               // ViewState["UserAllocationTable"] = UserAllocationTable;
                UserAllocationGrid.DataSource = UserAllocationTable;
                UserAllocationGrid.DataBind(); 
            }
        
