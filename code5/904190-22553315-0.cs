    if (Global.LoggedAdmin != null && IsRelevantColumn())
    {
        //code
    }
    private static bool IsRelevantColumn(){
        return LaunchDataGridView.CurrentCell.ColumnIndex == 5 ||
               LaunchDataGridView.CurrentCell.ColumnIndex == 6 ||
               LaunchDataGridView.CurrentCell.ColumnIndex == 9;
    }
