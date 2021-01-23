    public void RemoveRows()
    {
      var selectedrows = datagridview.SelectedRows.Cast<DataGridViewRow>();
      if (selectedrows.Count() == 0)
          return;
      var fromIndex = selectedrows.Last().Index;
      datagridview.Rows.Cast<DataGridViewRow>()
          .Where(p=>p.Index > fromIndex)
          .ToList()
          .ForEach(p=>datagridview.Rows.Remove(p));
    
    }
