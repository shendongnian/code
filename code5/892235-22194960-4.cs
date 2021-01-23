    public Color HasChanged(string value)
    {
        var date1 = _localShipment.GetType()
            .GetProperty(value)
            .GetValue(_localShipment, null);
        var date2 = _originalShipment.GetType()
            .GetProperty(value)
            .GetValue(_originalShipment, null);
        return date1 != date2 ? Colors.SkyBlue : Colors.White;
    }
