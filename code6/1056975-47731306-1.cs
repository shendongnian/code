    public Task OnNavigatedToAsync(object parameter, NavigationMode mode)
    {
        if (parameter != null)
        {
	        YourThing thing = parameter as YourThing;
	        this.UseYourThing(thing);
	    }
        return Task.CompletedTask;
    }
