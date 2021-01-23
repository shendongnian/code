    public class NearMeView : ContentPage
    	{
    		private ListView _listView;
    		private MyViewModel _viewModel;
    		public NearMeView ()
    		{
    			_viewModel = new MyViewModel ();
    			BindingContext = _viewModel;
    			_listView = new ListView (){
    				ItemTemplate = CreateItemTemplate ()//Here you will set th data templates for each row and in each label nameLabel.SetBinding<Item> (Label.TextProperty, x => x.Name);
    			};
    			_branchesListView.SetBinding<MyViewModel> (ListView.ItemsSourceProperty, x => x.Rows);
    }
    
    public class MyViewModel : ViewModel
    {
         List<Item>Rows;//will be populated from your DB each item will represent a Row, so you just need to remove from this list the item and automatically from the View should be removed the row.
        // Method that you need to remove filter etc.
    }
    private DataTemplate CreateBranchItemTemplate ()
    		{
    			return new DataTemplate (() => {
    				var nameLabel = new Label ();
    				var typeLabel = new Label ();
    				var distanceLabel = new Label (){	HorizontalOptions = LayoutOptions.EndAndExpand,VerticalOptions = LayoutOptions.Center	};
    				nameLabel.SetBinding<BranchModel> (Label.TextProperty, x => x.Name);
    				typeLabel.SetBinding<BranchModel> (Label.TextProperty, x => x.Type);
    				distanceLabel.SetBinding<BranchModel> (Label.TextProperty,x=> x.Distance);
    				var leftStack = new StackLayout (){
    					Orientation = StackOrientation.Vertical,
    					VerticalOptions = LayoutOptions.Center,
    					Children = { nameLabel, typeLabel },
    					Padding = new Thickness (8,0,0,0)
    
    				};
    				return new ViewCell () {
    					View = new StackLayout () {
    						Orientation = StackOrientation.Horizontal,
    						Spacing = 5,
    						Children = { leftStack, distanceLabel },
    						Padding = new Thickness (0,0,0,8)
    					}
    				};
    			});
    		}
    	
		
