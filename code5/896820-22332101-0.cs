    private ICollectionView customView;
    public ICollectionView CustomView
    {
       get
       {
          if (customView== null)
          {
             customView= new CollectionViewSource()
                         { Source = SourceCollection }.View;
             customView.Filter = p => !(p as CustomClass).BoolProperty;
          }
          return customView;
       }
     }
