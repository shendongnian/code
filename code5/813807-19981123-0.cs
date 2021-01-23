    public void UserIdentification()
    {
        // Verify that c_LOB exists before we try to use it
        if(c_LOB != null)
        {
            c_LOB.Items.Clear();
            c_LOB.Items.Add("RUSA");
            c_LOB.Items.Add("RETAIL");
            c_LOB.Items.Add("CARDS");
        }
        ...
    }
