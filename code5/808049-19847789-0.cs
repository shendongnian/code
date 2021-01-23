    <ListBox x:Name="list" ItemsSource="{Binding SavedTracksCollection}"
        SelectedItem="{Binding SelectedItemTrack,Mode=TwoWay}"
        SelectionChanged="List_OnSelectionChanged"/>
    // in code behind
    private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // navigate here after validating the selected item  
        // or raise Command in your ViewModel programatically  
    }
