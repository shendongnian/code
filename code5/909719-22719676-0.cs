    for (int ColCount = 0; ColCount < dtnew.Columns.Count; ColCount++)
    {
       if (dtnew.Columns[ColCount].ColumnMapping == MappingType.Hidden)
       {
          dtnew.Columns[ColCount].ColumnMapping = MappingType.Element;
       }
    }
