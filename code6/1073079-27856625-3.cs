    public delegate void GenericListItemCountChangedEvent(IEnumerable<BaseElem> sender,
                             GenericListItemCountChangedEventArgs e);
    public event GenericListItemCountChangedEvent GenericListItemCountChanged;
    
    private void RaiseGenericListItemCountChanged(IEnumerable<BaseElem> List)
    {
        if (GenericListItemCountChanged != null)
        {
            var itemType = List.Count() > 0 ? List.First().GetType() : typeof(BaseElem);
            GenericListItemCountChanged(List,
                new GenericListItemCountChangedEventArgs(itemType));
        }
    }
