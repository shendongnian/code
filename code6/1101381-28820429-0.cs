    private List<Search> FilterSearchResults(List<Search> results)
    {
        string _dataType = cmbISDataType.SelectedItem.ToString();
        string _medium = cmbISMedium.SelectedItem.ToString();
        string _pStatus = cmbISPStatus.SelectedItem.ToString();
        string _rStatus = cmbISRStatus.SelectedItem.ToString();
        IEnumerable<Search> query = results;
        if (!string.IsNullOrWhiteSpace(_dataType))
            query = query.Where(a => a.Data_Type == _dataType);
        if (!string.IsNullOrWhiteSpace(_medium))
            query = query.Where(b => b.Medium == _medium);
        if( !string.IsNullOrWhiteSpace(_pStatus))
            query = query.Where(c => c.PStat == _pStatus);
        if( !string.IsNullOrWhiteSpace(_rStatus))
            query = query.Where(d => d.RStatus == _rStatus);
        return query.ToList();
    }
