    void MyCVS_Filter(object sender, FilterEventArgs e)
    {
        CustomerViewModel item = e.Item as CustomerViewModel;
        if (item.IsCompany)
        {
            e.Accepted = true;
        }
        else
        {
            e.Accepted = false;
        }
    }
