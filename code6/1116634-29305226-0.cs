    public static class MyExtensions
    {
        public static void SetDataAndAutoCompleteSource<T>(this ComboBox cmb, IEnumerable<T> src)
        {
            cmb.DataSource = src;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection aSrc = new AutoCompleteStringCollection();
            aSrc.AddRange(src.Select(c => c.ToString()).ToArray());
            cmb.AutoCompleteCustomSource = aSrc;
        }
    }
