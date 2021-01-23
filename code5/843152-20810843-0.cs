    public Guid? SelectedItemGUID
    {
    get
    {
        if (SelectedItem == null) return null;
        else return (Guid?)SelectedItem.GetType().GetProperty("GUID").GetValue(SelectedItem, null);
    }
