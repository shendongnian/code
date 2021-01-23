    ObservableCollection<string> leftSideList = new ObservableCollection<string>();
    ObservableCollection<string> rightSideList = new ObservableCollection<string>();
    
    public ChooseLPWindow()
    {
    	InitializeComponent();
    
    	leftSideList.Add("360T");
    	leftSideList.Add("BARX");
    	leftSideList.Add("BNP");
    	leftSideList.Add("BOA");
    	leftSideList.Add("CITI");
    	leftSideList.Add("CS");
    	leftSideList.Add("DB");
    	leftSideList.Add("GS");
    	leftSideList.Add("JPM");
    	leftSideList.Add("RBS");
    	leftSideList.Add("UBS");
    	
    	LeftList.ItemsSource = leftSideList;
    }
    
    private void AddBtn_Click(object sender, RoutedEventArgs e)
    {
    	if (LeftList.SelectedIndex > -1)
    	{
    		int SelectedIndex = LeftList.SelectedIndex;
    		string SelectedItem = LeftList.SelectedValue.ToString();
    
    		//Add the selected item to the right side list
    		RightList.Items.Add(SelectedItem);
    		rightSideList.Add(SelectedItem);
    
    		if (leftSideList != null)
    		{
    			//Remove the item from the ItemsSource collection 
    			//instead of removing it from ListBox.Items
    			leftSideList.RemoveAt(SelectedIndex);
    		}
    	}
    }
