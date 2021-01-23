    public delegate void GenericListItemCountChangedEvent(List<BaseElem> sender,
                             GenericListItemCountChangedEventArgs e);
    public event GenericListItemCountChangedEvent GenericListItemCountChanged;
    
    private void RaiseGenericListItemCountChanged<T>(List<T> List) where T : BaseElem
    {
        if (GenericListItemCountChanged != null)
        {
            GenericListItemCountChanged(List.Cast<BaseElem>().ToList(),
                new GenericListItemCountChangedEventArgs(typeof(T)));
        }
    }
