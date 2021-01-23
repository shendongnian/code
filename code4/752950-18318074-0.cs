    private void FillComboFromColumnIndex(int columnIndex){
      yourDataTable.AsEnumerable()
                   .Select(r=>r[columnIndex])
                   .Where(x=>x != null)
                   .Distinct().ToList()
                   .ForEach(x=>yourComboBox.Items.Add(x));
    }
    //To add all the items in column at index 1, do this
    FillComboFromColumnIndex(1);
