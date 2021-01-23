    private DataView ActiveGrid
    {
        get 
        {
            if (TabPanel.IsInitialized)
            {
                switch (TabPanel.SelectedIndex)
                {
                    case 0: return (DataView)Grid1.ItemsSource;
                    case 1: return (DataView)Grid2.ItemsSource;
                }
            }
            return null;
        }
    }
