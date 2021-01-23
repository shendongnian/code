        public ObservableCollection<FavoriteItemViewModel> Favorites
        {
            get
            {
                return _favorites ?? (this.LoadFavorites(App.MainViewModel.Favorites));
            }
            set
            {
                _favorites = value;
            }
        }
