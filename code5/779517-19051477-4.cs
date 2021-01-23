    [Register("UIDataBoundCollectionView")]
    public class UIDataBoundCollectionView : UICollectionView,
      IEnableLogger
    {
      public UIDataBoundCollectionView (NSObjectFlag t) : base(t)
      {
      }
    
      public UIDataBoundCollectionView (IntPtr handle) : base(handle)
      {
      }
    
      public UIDataBoundCollectionView (RectangleF frame, UICollectionViewLayout layout) : base(frame, layout)
      {
      }
    
      public UIDataBoundCollectionView (NSCoder coder) : base(coder)
      {
      }
    
      protected override void Dispose(bool disposing)
      {
        base.Dispose(disposing);
    
        if(collectionChangedSubscription != null)
        {
          collectionChangedSubscription.Dispose();
          collectionChangedSubscription = null;
        }
      }
    
      IDisposable collectionChangedSubscription;
    
      public override NSObject WeakDataSource
      {
        get
        {
          return base.WeakDataSource;
        }
    
        set
        {
          if(collectionChangedSubscription != null)
          {
            collectionChangedSubscription.Dispose();
            collectionChangedSubscription = null;
          }
    
          base.WeakDataSource = value;
    
          collectionChangedSubscription = ICVS.CollectionChangedObservable
            .Subscribe(OnDataSourceCollectionChanged);
        }
      }
    
      ICollectionViewDataSource ICVS
      {
        get { return (ICollectionViewDataSource) WeakDataSource; }
      }
    
      void OnDataSourceCollectionChanged(NotifyCollectionChangedEventArgs[] changes)
      {
        List<NSIndexPath> indexPaths = new List<NSIndexPath>();
        int index = 0;
    
        for(;index<changes.Length;index++)
        {
          var e = changes[index];
    
          switch(e.Action)
          {
            case NotifyCollectionChangedAction.Add:
              indexPaths.AddRange(IndexPathHelper.FromRange(e.NewStartingIndex, e.NewItems.Count));
              ICVS.ItemCount++;
    
              // attempt to batch subsequent changes of the same type
              if(index < changes.Length - 1)
              {
                for(int i=index + 1; i<changes.Length; i++)
                {
                  if(changes[i].Action == e.Action)
                  {
                    indexPaths.AddRange(IndexPathHelper.FromRange(changes[i].NewStartingIndex, changes[i].NewItems.Count));
                    index++;
                    ICVS.ItemCount++;
                  }
                }
              }
    
              InsertItems(indexPaths.ToArray());
              indexPaths.Clear();
              break;
            
            case NotifyCollectionChangedAction.Remove:
              indexPaths.AddRange(IndexPathHelper.FromRange(e.OldStartingIndex, e.OldItems.Count));
              ICVS.ItemCount--;
    
              // attempt to batch subsequent changes of the same type
              if(index < changes.Length - 1)
              {
                for(int i=index + 1; i<changes.Length; i++)
                {
                  if(changes[i].Action == e.Action)
                  {
                    indexPaths.AddRange(IndexPathHelper.FromRange(changes[i].OldStartingIndex, changes[i].OldItems.Count));
                    index++;
                    ICVS.ItemCount--;
                  }
                }
              }
    
              DeleteItems(indexPaths.ToArray());
              indexPaths.Clear();
              break;
            
            case NotifyCollectionChangedAction.Replace:
            case NotifyCollectionChangedAction.Move:
              PerformBatchUpdates(() =>
              {
                for(int i=0; i<e.OldItems.Count; i++)
                  MoveItem(NSIndexPath.FromItemSection(e.OldStartingIndex + i, 0), NSIndexPath.FromItemSection(e.NewStartingIndex + i, 0));
              }, null);
              break;
    
            case NotifyCollectionChangedAction.Reset:
              ICVS.ItemCount = ICVS.ActualItemCount;
              ReloadData();
              break;
          }
        }
      }
    }
