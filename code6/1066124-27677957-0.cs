    /// <summary>
    /// Enhanced List View
    /// 
    /// SeletionMode Switching:
    /// This class enhances ListView to support changing the selection mode from None/Single to Multiple and back and having it
    /// bind the selected items without forgetting them when changing selection mode.  The base ListView will remove the selected items when switching
    /// from Multiple SelectionMode to another SelectionMode.
    /// 1) Created SelectedItems2 to bind to View Model as SelectedItems will have items removed and SelectedItems is not easy to bind to SelectedItems.
    /// 2) On SelectionChanged, remember the selected items in SelectedItems2 how the user selected or unselected them.
    /// 3) On SelectionMode set to Multiple, fill the underlying SelectedItems with the values from SelectedItems2 so that the checkboxes are checked on the ListView.
    /// 4) Use _isMergingItems flag to ignore selection changed events being fired by merging of the SelectedItem2 and SelectedItems2 collections.
    /// 
    /// Doesn't support changing SelectedItems2 bound collection while in Multiple SelectionMode yet.
    /// To do so we would need to hook the CollectionChanged event on the SelectedItems2 List object that is bound.
    /// and likely handle threading issues with the merging of SelectedItems and SelectedItems2.
    /// </summary>
    public class MyListView : ListView
    {
        private bool _isMergingItems;
        public MyListView()
        {
            SelectionChanged += MyListView_SelectionChanged;
        }
        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ignore selection changed event when selection mode is not multiple.
            // This is mainly here because when changing from Multiple to Single, this event is fired and will cause
            // the items to be removed from SelectedItems2 which is not what is desired.
            if (SelectionMode != ListViewSelectionMode.Multiple) { return; }
            if (_isMergingItems) { return; }
            try
            {
                _isMergingItems = true;
                var selectedItems2List = SelectedItems2 as IList;
                if (selectedItems2List == null) { return; }
                foreach (var itemToAdd in e.AddedItems)
                {
                    selectedItems2List.Add(itemToAdd);
                }
                foreach (var itemToRemove in e.RemovedItems)
                {
                    selectedItems2List.Remove(itemToRemove);
                }
            }
            finally
            {
                _isMergingItems = false;
            }
        }
        #region --- Dependency Properties ---
        private static readonly DependencyProperty SelectionMode2Property = DependencyProperty.Register("SelectionMode2", typeof(ListViewSelectionMode), typeof(MyListView), new PropertyMetadata(ListViewSelectionMode.None, SelectionMode2Changed));
        public ListViewSelectionMode SelectionMode2
        {
            get { return (ListViewSelectionMode)GetValue(SelectionMode2Property); }
            set { SetValue(SelectionMode2Property, value); }
        }
        private static void SelectionMode2Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = d as MyListView;
            var value = (ListViewSelectionMode)e.NewValue;
            // Set the underlying selection mode property to cause the control to 
            // change to and from Multiple selection mode.
            listView.SelectionMode = value;
            // When Multiple selction mode, we will need to load the underlying SelectedItems of the ListView
            // so that the checkboxes are checked appropriatly.  When the selection mode is changed the underlying ListView
            // removes the selected items.
            if (value == ListViewSelectionMode.Multiple)
            {
                listView.FillUnderlyingSelectedItems();
            }
        }
        private static readonly DependencyProperty SelectedItems2Property = DependencyProperty.Register("SelectedItems2", typeof(object), typeof(MyListView), null);
        /// <summary>
        /// SelectedItems2 is used as the property to bind the selected items to the ViewModel.
        /// Using a List as the data type did not seem to work for binding.  Since ItemSource is an object on the base class
        /// object was chosen for this property as well.
        /// 
        /// However, SelectedItems2 will need to bind to IList in order for it to work properly.
        /// </summary>
        public object SelectedItems2
        {
            get { return (object)GetValue(SelectedItems2Property); }
            set { SetValue(SelectedItems2Property, value); }
        }
        #endregion
        private void FillUnderlyingSelectedItems()
        {
            var selectedItems2List = SelectedItems2 as IList;
            if (selectedItems2List == null) { return; }
            try
            {
                _isMergingItems = true;
                foreach (var item in selectedItems2List)
                {
                    SelectedItems.Add(item);
                }
            }
            finally
            {
                _isMergingItems = false;
            }
        }
    }
