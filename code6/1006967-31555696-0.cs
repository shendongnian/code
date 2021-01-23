    public class ItemsPage : ContentPage
    {
	ItemListView list;
	SearchBar searchbar;
	public ItemsPage ()
	{
		Title = "Items";
		list = new ItemListView ();
		searchbar = new SearchBar () {
			Placeholder = "Search",
		};
		searchbar.TextChanged += (sender, e) => {
			/*Work to be done at time text change*/
		};
		searchbar.SearchButtonPressed += (sender, e) => {
			/*Work to be done at time of Search button click*/
		};
		var stack = new StackLayout () {
			Children = {
				searchbar,
				list
			}
		};
		Content = stack;
	}
	}
