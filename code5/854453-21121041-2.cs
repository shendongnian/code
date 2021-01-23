    public ParagonCollection()
    {
       // When the collection changes set the Sum to the new Sum of TotalValues
       this.CollectionChanged += OnCollectionChanged;
    }
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      Recalculate();
    }
    private void Recalculate()
    {
      Sum = this.Sum(x=>x.TotalValue);
    }
