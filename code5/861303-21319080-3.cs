    private void UpdateComponents(string[] request)
    {
        foreach (string r in request)
        {
            if (r == "ListViewSubnetworksChanged")
            {
                ClearListViewItemsSafe();
                return;
            }
        }
    }
