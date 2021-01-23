    public interface ICollectionViewDataSource
    {
      /// <summary>
      /// Gets the bound item at the specified index
      /// </summary>
      /// <param name="indexPath">The index path.</param>
      /// <returns></returns>
      object GetItemAt(NSIndexPath indexPath);
    
      /// <summary>
      /// Gets the actual item count.
      /// </summary>
      /// <value>The item count.</value>
      int ActualItemCount { get; }
    
      /// <summary>
      /// Gets or sets the item count reported to UIKit
      /// </summary>
      /// <value>The item count.</value>
      int ItemCount { get; set; }
    
      /// <summary>
      /// Observable providing change monitoring
      /// </summary>
      /// <value>The collection changed observable.</value>
      IObservable<NotifyCollectionChangedEventArgs[]> CollectionChangedObservable { get; }
    }
