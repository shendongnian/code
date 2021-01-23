    private void LaunchButton_Click(object sender, RoutedEventArgs e)
    {
        var row=dataGrid1.SelectedItem as System.Data.DataRowView;
        if(row!=null)
        {
           string gamePath = row["Path"].ToString();
           Process.Start(gamePath);
        }
    }
