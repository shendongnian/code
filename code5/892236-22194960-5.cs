    public static T Get<T>(this object obj, string name)
    {
        return obj.GetType().GetProperty(name).GetValue(obj, null);
    }
    ...
    return _localShipment.Get<DateTime>(value) != _originalShipment.Get<DateTime>(value) ? Colors.SkyBlue : Colors.White;
