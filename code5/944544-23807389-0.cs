        private void applySortDescriptions(DataGridColumn col, ListSortDirection listSortDirection)
        {
            //Clear current sort descriptions
            MyDataGrid.Items.SortDescriptions.Clear();
            //Get property name to apply sort based on desired column
            string propertyName = getSortPropertyName(col);           
            //Add the new sort description
            MyDataGrid.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
           
            //apply sort
            applySortDirection(col, listSortDirection);           
           
            //refresh items to display sort
            MyDataGrid.Items.Refresh();
        }
        private string getSortPropertyName(DataGridColumn col)
        {
            //place logic in here that will return the name of the property to sort by (ex: return “name”; if you are sorting by the name property)
            return string.Empty;
        }
        private void applySortDirection(DataGridColumn col, ListSortDirection listSortDirection)
        {
            foreach (DataGridColumn c in PatientsViewDatGrid.Columns)
            {
                c.SortDirection = null;
            }
            col.SortDirection = listSortDirection;
        }
