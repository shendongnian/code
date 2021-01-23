    public delegate void GenericListItemCountChangedEvent(IList<BaseElem> sender,
                             GenericListItemCountChangedEventArgs e);
    public event GenericListItemCountChangedEvent GenericListItemCountChanged;
    
    private void RaiseGenericListItemCountChanged(List<BaseElem> List)
    {
        if (GenericListItemCountChanged != null)
        {
            GenericListItemCountChanged(List as List<Object>,
                new GenericListItemCountChangedEventArgs(typeof(T)));
        }
    }
