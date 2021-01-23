    public static class GridViewExtensions
    {
        public static DataControlField GetColumnByHeaderText(this DataControlFieldCollection dataControlFieldCollection , string headerText)
        {
            foreach(var column in DataControlFieldCollection)
            {
                if(column.HeaderText==headerText)
                    return column;
            }
        }
    }
