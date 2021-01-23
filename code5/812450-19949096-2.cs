     private void Submit_Click(object sender, EventArgs e)
        {
            //propertyGrid1.SelectedObject = this;
            dataGridView1.Columns.Add("Property", "Property");
            dataGridView1.Columns.Add("Value", "Value");
            GridItem gi = propertyGrid1.SelectedGridItem;
            while (gi.Parent != null)            
                gi = gi.Parent;
            
            foreach (GridItem item in gi.GridItems)            
                ParseGridItems(item); //recursive
            
            dataGridView1.Sort(dataGridView1.Columns["Property"], ListSortDirection.Ascending);
        }
        private void ParseGridItems(GridItem gi)
        {
            if (gi.GridItemType == GridItemType.Category)            
                foreach (GridItem item in gi.GridItems)                
                    ParseGridItems(item);                
            
            dataGridView1.Rows.Add(gi.Label, gi.Value);
          
        }
