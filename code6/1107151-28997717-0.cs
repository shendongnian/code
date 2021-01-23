    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        if (SessionFormData.ConfirmedIraDistribution)
        {
            iraDistribution.Attributes.Clear();
        }
        else if (SessionFormData.ConfirmedIraDistribution == false
            && SessionFormData.IraDistribution.HasValue
            && SessionFormData.IraDistribution.Value > 0)
        {
            iraDistribution.Attributes[_data_confirm] =
                "<div>You must submit a copy of the first page of your 2014 federal tax return to verify the rollover amount.</div>";
            iraDistribution.Attributes[_aria_live] = "assertive";
            SessionFormData.ConfirmedIraDistribution = true;
        }
    }
