`c#
public ObservableCollection<T> HeldCollection{ get; set; }
        
        #region properties for the view
        CollectionView _HeldView;
        public CollectionView HeldView
        {
            get
            {
                if (_HeldView == null)
                {
                    _HeldView = (CollectionView)CollectionViewSource.GetDefaultView(HeldCollection);
                    //_HeldView.GroupDescriptions.Add(GroupDescription);
                }
                return _HeldView;
            }
        }
`
You can then edit the GroupDescription since it is a property of the CollectionView, for example in response to a button toggle.
