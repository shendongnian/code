    private DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
    {
        // Add all names to a list
        List<string> clientsSelected = new List<string>();
        foreach (Clients c in ClientDataGrid.SelectedItems)
        {
            clientsSelected.Add(c.Hostname);
        }
        //Build string of hostnames that are changing and set to textbox text
        hostNameList.Text = string.Join(", ", clientsSelected);
    }
