    for(int i = deleteDevice.Count - 1; i>=0; i--)
    {
        string split = deleteDevice[i].Split(',');
        List<string> parts = split.ToList(); 
        if (parts.Contains(deviceList.SelectedItem.ToString()))
        {
            deleteDevice.Remove(i);
        }
    }
    ... write to file...
