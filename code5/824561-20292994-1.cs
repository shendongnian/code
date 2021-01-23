    private void tbName_Click(object sender, RoutedEventArgs e)
    {
    	if (tbName.IsChecked.Value)
    	{
    		ListBoxEffects.ItemTemplate = this.FindResource("TempalteWithoutName") as DataTemplate;
    	}
    	else
    	{
    		ListBoxEffects.ItemTemplate = this.FindResource("TemplateWithName") as DataTemplate;
    	}
    }
