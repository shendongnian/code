    const int numberOfColumns = 20;
    for (int i = 0; i < numberOfColumns; i++) {
        var statIndex = i;
        var column = new OLVColumn();
        column.Name = "Stat" + i;
        column.AspectGetter = delegate(object x) {
            MyStruct myStruct = (MyStruct)x;
            return statIndex < myStruct.ItemStatValue.Length ? (uint?)myStruct.ItemStatValue[statIndex] : null;
        };
        column.AspectToStringConverter = delegate(object x) {
            uint? value = (uint?)x;
            return value.HasValue ? String.Format("Stat value: {0}", value.Value) : String.Empty;
        };
        this.ContentListView.AllColumns.Add(column);
    }
    this.ContentListView.RebuildColumns();
