    DataTable DT = new DataTable();
    DT.Columns.Add ("Radii");
    DT.Columns.Add ("Phis");
    
    if (Radii.Count == Phis.Count ) {
        for (int i = 0; i < Radii.Count; i++ ) {
             DT.Columns.Rows.Add(new String[] {Radii[i].ToString(), Phis[i].ToString()})
        }
    }
    DataGrid DG = new DataGrid();
    DG.ItemsSource = DT.DefaultView;
