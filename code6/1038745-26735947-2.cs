    public void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListData.SelectedIndex != -1)
        {
            historyTableSQlite listitem = ListData.SelectedItem as historyTableSQlite;
            int Selected_HistoryId = listitem.Id;
            // this.Selected_HistoryId = listitem.Id;
            // you need to set the Property not a local variable
        }
    }
