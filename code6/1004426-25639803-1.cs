    public static class Extensions
    {
        public static int GetColumnIndex(this DataControlFieldCollection columns, string columnName, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
        {
            for(int index = 0; index <  columns.Count; index++)
                if(columns[index].HeaderText.Equals(columnName, comparison))
                    return index;
            return -1;
        }
    }
