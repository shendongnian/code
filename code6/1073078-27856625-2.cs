    public class YourClass<T> where T : BaseElem
    {
        public delegate void GenericListItemCountChangedEvent<T>(List<T> sender,
                                 GenericListItemCountChangedEventArgs e);
        public event GenericListItemCountChangedEvent<T> GenericListItemCountChanged;
    
        private void RaiseGenericListItemCountChanged<T>(List<T> List)
        {
            if (GenericListItemCountChanged != null)
            {
                GenericListItemCountChanged(List,
                   new GenericListItemCountChangedEventArgs(typeof(T)));
            }
        }
    }
