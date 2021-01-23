    public class ViewableCollection<T> : ObservableCollection<T>
        {
            private ListCollectionView _View;
            public ListCollectionView View
            {
                get
                {
                    if (_View == null)
                    {
                        _View = new ListCollectionView(this);
                    }
                    return _View;
                }
            }
        }
