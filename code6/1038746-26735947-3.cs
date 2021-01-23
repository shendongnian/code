    public void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListData.SelectedIndex != -1)
        {
            historyTableSQlite listitem = ListData.SelectedItem as historyTableSQlite;
            // this will get destroy when the function exits, it's local decalartion
            int Selected_HistoryId = listitem.Id;
            // History.Selected_HistoryId = listitem.Id;
            // you need to set the Property not a local variable
        }
    }
