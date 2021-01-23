        private void PopulateListBoxes(Dictionary<ListBox, string> ListBoxCollection, DataTable CustomerTable)
        {
            
            foreach(var key in ListBoxCollection.Keys)
            {
                key.DisplayMember = ListBoxCollection[key];
                key.DataSource = CustomerTable;
            }
        }
