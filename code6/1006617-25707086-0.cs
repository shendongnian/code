    private void DeleteAction(object actionParameter)
    {
    	List<object> selectedFavorites = 
    					new List<object>(actionParameter as List<object>);
    	foreach (var item in selectedFavorites)
    	{
    		this.Favorites.Remove((FavoriteItemViewModel)item);
    	}
    }
