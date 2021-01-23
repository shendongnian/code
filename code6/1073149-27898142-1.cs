    Wrapper nearMeVM = new Wrapper();
    public NearMe ()
    		{
    
    			Binding myBinding = new Binding("List");
    			myBinding.Source = nearMeVM;
    			myBinding.Path ="List";
    			myBinding.Mode = BindingMode.TwoWay;
    			listView.SetBinding (ListView.ItemsSourceProperty, myBinding); 
    			listView.ItemTemplate = new DataTemplate(typeof(FilialeCell));
                searchBar = new SearchBar {
    				Placeholder="Search"
    			};
    			searchBar.TextChanged += (sender, e) => {
    				TextChanged(searchBar.Text);
    			};
    			var stack = new StackLayout { Spacing = 0 };
    			stack.Children.Add (searchBar);
    			stack.Children.Add (listView);
    			Content = stack;
    		}
    public void TextChanged(String text){
    			if (!String.IsNullOrEmpty (text)) {
    				text = text [0].ToString ().ToUpper () + text.Substring (1);
    				var filterSedi = nearMeVM.List.Where (filiale => filiale.nome.Contains (text));
    				var newList = filterSedi.ToList ();
    				nearMeVM.List = newList.OrderBy (x => x.distanza).ToList ();
    			} else {
    				nearMeVM.Reinitialize ();
    			}
