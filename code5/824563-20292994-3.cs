    private void tbName_Click(object sender, RoutedEventArgs e)
    {
    	if (tbName.IsChecked.Value)
    	{
    		ListBoxEffects.ItemTemplate = this.FindResource("TemplateWithoutName") as DataTemplate;
    	}
    	else
    	{
    		ListBoxEffects.ItemTemplate = this.FindResource("TemplateWithName") as DataTemplate;
    	}
    }
