    public delegate void SimpleSubDataChangedDelegate(CategoricalDataItem sender,
                                             CategoricalDataItemCollection oldValue,
                                             CategoricalDataItemCollection newValue
    public class CategoricalDataItem
    {
        CategoricalDataItemCollection _simpleSubData;
       
        ...
    
        public CategoricalDataItemCollection SimpleSubData 
        { 
            get { return _simpleSubData; }
            set 
            {
                 if (_simpleSubData != null)
                     _simpleSubData.CollectionChanged -= OnSimpleSubDataChanged;
    
                 var oldValue = _simpleSubData;
                 _simpleSubData = value;
    
                 if (_simpleSubData != null)
                     _simpleSubData.CollectionChanged += OnSimpleSubDataChanged;
    
                 // Invoke the new event that should alert all parents.
                 if (SubDataChanged != null)
                     SubDataChanged(this, oldValue, _simpleSubData);
            }
        }
        
        public event SimpleSubDataChangedDelegate SubDataChanged;
        void OnSimpleSubDataChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // There are other NotifyCollectionChangedAction that should be handled.
            foreach(var oldItem in e.OldItems)
            {
                if (e.Action == NotifyCollectionChangedAction.Removed)
                    oldItem.SubDataChanged -= SubDataChanged;
            }
            foreach(var newItem in e.NewItems)
            {
                if (e.Action == NotifyCollectionChangedAction.Added)
                    oldItem.SubDataChanged += SubDataChanged;
            }
        }
    }
