    var pilots = new List<Pilots>(grid.SelectedRows.Count);
    
    for(int index = 0; index < grid.SelectedRows.Count; index++)
    {
       var selectedRow = grid.SelectedRows[index];
       var pilot = (Pilots)selectedRow.DataBoundItem;
    
       pilots.Add(pilot);
    }
