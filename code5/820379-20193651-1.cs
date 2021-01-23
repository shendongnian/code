    int groupIdentifier = this.dataGridView.Rows[0].Cells["Group"].Value;
    
    this.dataGridView.Rows[0].Cells["Group"].Value = GetGroupName(groupIdentifier);
    
    List<Groups> ListGroups = new List<Groups>();
    
    private string GetGroupName(int groupIdentifier)
    {
        var group = ListGroups.FirstOrDefault(g=>g.Id == groupIdentifier);
        return group.Name;
    }
    
    dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
    void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null)
           return;
       string stringValue = (string)e.Value;
        stringValue = stringValue.ToLower();
    
        if (e.Value == "1")
        {
           e.Value = "string for one";
           e.FormattingApplied = true;
        }
    }
