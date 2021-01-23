     private ICollectionView MyView {get;set;}
     this.MyView = CollectionViewSource.GetDefaultView(this._items);
     if (!this.MyView.IsCurrentBeforeFirst)
     {
         this.MyView.MoveCurrentToPrevious();
     }
        
