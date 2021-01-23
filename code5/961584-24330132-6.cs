    private void Initialize_DataGridView()
    {
        // Add dummy data to generate the columns
        this.dataGridView_Items.DataContext = new Item[]{ new Item {Id = 5, Value = 6}};
        
        // Make your formatting
        foreach (DataGridViewRow row in grdComponents.Rows)
        {
            row.HeaderCell.Value = row.Cells[0].Value.ToString();
        }
        
        grdComponents.Columns[0].Visible = false;
        
        // Reset the dummy data
        this.dataGridView_Items.DataContext = null; // Or new Item[]{};
    }
    
    ...
    public MyForm()
    {
        Initialize();
     
        this.Initialize_DataGridView();   
    }
