    private void icon_Add(object sender, RoutedEventArgs e)
    {
        OpenView(typeof(viewName));
    }
    
    private void OpenView(Type newView)
    {
    	if(typeof(Window).IsAssignableFrom(newView)) {
    		Window window = (Window)Activator.CreateInstance(newView);
    		window.Show();
    		window.Close();
    	}
    }
