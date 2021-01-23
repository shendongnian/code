    if (Tonnage.IsChecked.HasValue && Tonnage.IsChecked.Value)
    {
        query = query.Where(s => s.Tons != "0" && s.Tons != "")
    }
    if (null != FilterWaterWay.SelectedValue)
    {
        string WaterwaytoFilterBy = FilterWaterWay.SelectedValue.ToString();
        if (!string.IsNullOrWhiteSpace(WaterwaytoFilterBy) && WaterwaytoFilterBy != "[Select WaterWay]")
        {
             query = query.Where(s => s.WTWY_NAME == WaterwaytoFilterBy);
        }
    }
    if (null != FilterState.SelectedValue)
    {
        string StateToFilterBy = FilterState.SelectedValue.ToString();
        if (null != FilterState.SelectedValue && !string.IsNullOrWhiteSpace(StateToFilterBy) && StateToFilterBy != "[Select State]")
        {
             query = query.Where(s => s.STATE == StateToFilterBy);
        }
    }
