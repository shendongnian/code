    public NodeView()
    	{
    			var dt = FindResource("DefaultNodeContent") as DataTemplate;
    			var lb = new ItemsControl();
    			lb.ItemTemplate = dt;
    			var binding = new Binding("Children");
    			lb.SetBinding(ItemsControl.ItemsSourceProperty, binding);
    
    			var gb = new GroupBox();
    			gb.Content = lb;
    			this.Content = gb;
    
    	}
