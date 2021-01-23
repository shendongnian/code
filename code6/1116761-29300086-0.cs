    <ListView Name="Items" ItemsSource={Binding Items}>
    	<ListView.View>
    		<GridView>
    			<GridViewColumn Width="200" Header="First name" DisplayMemberBinding="{Binding FirstName}"></GridViewColumn>
    			<GridViewColumn Width="200" Header="Last name" DisplayMemberBinding="{Binding LastName}"></GridViewColumn>
    		</GridView>
    	</ListView.View>
    </ListView>
    private ObservableCollection<Contact> items;
    public ObservableCollection<Contact> Items
    {
    	get { return items; }
    	set
    	{
    		if (value != items)
    		{
    			items = value;
    			NotifyOfPropertyChange(() => Items);
    		}
    	}
    }
