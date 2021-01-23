    private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
        Config config = e.Item as Config;
        if (config != null)
        {
            if (config.ConfigGroup == "G1")
                e.Accepted = true;
            else
                e.Accepted = false;
        }
    }
