    private void dtGrdViewFamily_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
             //if(!(dtGrdViewFamily.Columns.Contains("Category"))
             //    return;
            foreach(DataGridViewRow row in dtGrdViewFamily.Rows)
            
            {
                if (!row.IsNewRow)
                {
                DataGridViewComboBoxCell rcCategories = new DataGridViewComboBoxCell();
                rcCategories.DataSource = GetRCCategories();
                rcCategories.DisplayMember = "Values";
                rcCategories.ValueMember = "Keys";
                
                row.Cells[9] = rcCategories;
               
            }
            }
          
        }
