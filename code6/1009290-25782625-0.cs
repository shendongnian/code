    string PreSelectedColor="Black";
    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
    	var defaultColor = 
    			BackGroundColorList.FirstOrDefault(o => o.BackGroundColorString == PreSelectedColor);
    	BackgroundColor.SelectedItem = defaultColor;
    }
