        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            var allControls = new List<DataGrid>();
            // Grab a list of all DataGrid controls.
            GetControlList(Page.Controls, allControls);
            var itemsFound = 
                allControls.Sum(childControl => childControl.Items.Count);
            
            for (var i = 0; i < allControls.Count; i++)
            {
                if (allControls.Count > 0 && allControls[i].ID == "grid")
                {
                    // If a single row is found, grab a reference to the
                    // ButtonColumn in the associated grid.
                    if (i == (allControls.Count - 1) && itemsFound == 1)
                    {
                        var singletonDataGrid = allControls[i];
                        singletonDataGrid.SelectedIndex = 0;
                        Select_Change(singletonDataGrid, new EventArgs());
                    }
                }
            }
            
        }
