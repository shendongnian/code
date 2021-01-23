        private void DeleteAction(object actionParameter)
        {
            List<object> selectedFavorites = actionParameter as List<object>;
            List<FavoriteItemViewModel> myList = new List<FavoriteItemViewModel>();
            foreach (var item in selectedFavorites)
            {
                myList.Add((FavoriteItemViewModel)item);
            }
            foreach (var item in myList)
            {
                this.Favorites.Remove(item);
            }
            myList.Clear();
            myList = null;
        }
