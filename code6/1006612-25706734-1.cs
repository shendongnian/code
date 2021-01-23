    private void DeleteAction(object actionParameter)
    {
        List<object> selectedFavorites = actionParameter as List<object>;
        foreach (FavoriteItemViewModel item in selectedFavorites)
        {
            FavoriteItemViewModel itemToDelete = 
            this.Favorites.FirstOrDefault<FavoriteItemViewModel>
            (m => m.Description.ToLowerInvariant() == item.Description.ToLowerInvariant());
                
            if (itemToDelete != null)
              this.Favorites.Remove(itemToDelete);
       }
     }
