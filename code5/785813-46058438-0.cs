    MessageBox.Show(
    
    string.Join(", ", myGrid.SelectedCells
                            .Select(cl => cl.Item.GetType()
                                                 .GetProperty(cl.Column.SortMemberPath)
                                                 .GetValue(cl.Item, null)))
    
                   );
