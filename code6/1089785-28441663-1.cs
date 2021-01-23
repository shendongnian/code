    private void GatherDays()
    {
        List<int> list = new List<int>();
        foreach (KeyValuePair<int, string> item in listBoxBuildDays.SelectedItems)
        {
            list.Add(item.Key);
        }
    }
