        private void DeleteAction(object actionParameter)
        {
            List<object> selectedFavorites = actionParameter as List<object>;
            List<FavoriteItemViewModel> myList = new List<FavoriteItemViewModel>();
            Favorites.RemoveAll(a => selectedFavorites.Exists(w =>     ((FavoriteItemViewModel)w).Description == a.Description));
            
            myList = null;
        }
