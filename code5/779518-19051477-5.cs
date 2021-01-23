    public class UICollectionViewDataSourceFlatReadOnly : UICollectionViewDataSource,
      ICollectionViewDataSource
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="UICollectionViewDataSourceFlat"/> class.
      /// </summary>
      /// <param name="table">The table.</param>
      /// <param name="items">The items.</param>
      /// <param name="cellProvider">The cell provider</param>
      public UICollectionViewDataSourceFlatReadOnly(IReadOnlyList<object> items, ICollectionViewCellProvider cellProvider)
      {
        this.items = items;
        this.cellProvider = cellProvider;
    
        // wire up proxying collection changes if supported by source
        var ncc = items as INotifyCollectionChanged;
        if(ncc != null)
        {
          collectionChangedObservable = Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
            h => ncc.CollectionChanged += h, h => ncc.CollectionChanged -= h)
            .SubscribeOn(TaskPoolScheduler.Default)
            .Select(x => x.EventArgs)
            .Buffer(TimeSpan.FromMilliseconds(100), 20)
            .Where(x => x.Count > 0)
            .Select(x => x.ToArray())
            .ObserveOn(RxApp.MainThreadScheduler)
            .StartWith(new[] { reset});   // ensure initial update
        }
    
        else
          collectionChangedObservable = Observable.Return(reset);
      }
    
      #region Properties
      private IReadOnlyList<object> items;
      private readonly ICollectionViewCellProvider cellProvider;
      IObservable<NotifyCollectionChangedEventArgs[]> collectionChangedObservable;
      static readonly NotifyCollectionChangedEventArgs[] reset = new[] { new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset) };
      #endregion
    
      #region Overrides of UICollectionViewDataSource
    
      public override int NumberOfSections(UICollectionView collectionView)
      {
        return 1;
      }
    
      public override int GetItemsCount(UICollectionView collectionView, int section)
      {
        return ItemCount;
      }
    
      /// <summary>
      /// Gets the cell.
      /// </summary>
      /// <param name="tableView">The table view.</param>
      /// <param name="indexPath">The index path.</param>
      /// <returns></returns>
      public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
      {
        // reuse or create new cell
        var cell = (UICollectionViewCell) collectionView.DequeueReusableCell(cellProvider.Identifier, indexPath);
    
        // get the associated collection item
        var item = GetItemAt(indexPath);
    
        // update the cell
        if(item != null)
          cellProvider.UpdateCell(cell, item, collectionView.GetIndexPathsForSelectedItems().Contains(indexPath));
    
        // done
        return cell;
      }
    
      #endregion
    
      #region Implementation of ICollectionViewDataSource
    
      /// <summary>
      /// Gets the item at.
      /// </summary>
      /// <param name="indexPath">The index path.</param>
      /// <returns></returns>
      public object GetItemAt(NSIndexPath indexPath)
      {
        return items[indexPath.Item];
      }
    
      public int ActualItemCount
      {
        get
        {
          return items.Count;
        }
      }
    
      public int ItemCount { get; set; }
    
      public IObservable<NotifyCollectionChangedEventArgs[]> CollectionChangedObservable
      {
        get
        {
          return collectionChangedObservable;
        }
      }
    
      #endregion
    }
