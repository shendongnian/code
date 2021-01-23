    public ICollectionView FilteredStars
        {
            get
            {
                ICollectionView source = CollectionViewSource.GetDefaultView(starData);
                source.Filter = new Predicate<object>(FilterStars);
                return source;
            }
        }
