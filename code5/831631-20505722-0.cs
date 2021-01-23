    public class MultiSelectListView : ListView
    {
    // Using a DependencyProperty as backing store
    public static readonly DependencyProperty SelectedValuesProperty =
      DependencyProperty.Register("SelectedValues", typeof(IList), typeof(MultiSelectListView), new PropertyMetadata(default(IList), OnSelectedItemsChanged));
    public IList SelectedValues
    {
      get { return (IList)GetValue(SelectedValuesProperty); }
      set { SetValue(SelectedValuesProperty, value); }
    }
    private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      // if selected items list implements INotifyCollectionChanged, we subscribe to its CollectionChanged event
      var element = (MultiSelectListView)d;
      if (e.OldValue != null && e.OldValue is INotifyCollectionChanged)
      {
        var list = e.OldValue as INotifyCollectionChanged;
        list.CollectionChanged -= element.OnCollectionChanged;
      }
      if (e.NewValue is INotifyCollectionChanged)
      {
        var list = e.NewValue as INotifyCollectionChanged;
        list.CollectionChanged += element.OnCollectionChanged;
      }
    }
    // when selection changes in the view, elements are added or removed from the underlying list
    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
      if (SelectedValues != null)
      {
        foreach (var item in e.AddedItems)
        {
          if (!SelectedValues.Contains(item))
            SelectedValues.Add(item);
        }
        foreach (var item in e.RemovedItems)
        {
          if (SelectedValues.Contains(item))
            SelectedValues.Remove(item);
        }
      }
      base.OnSelectionChanged(e);
    }
    // when underlying list changes, we set the control's selected items to the contents of the list
    void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (SelectedValues != null)
      {
        SetSelectedItems(SelectedValues);
      }
    }
    }
