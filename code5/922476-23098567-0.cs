	interface IMainView
	{
		// give these better names based on what they actually represent (e.g. FirstName and LastName)
		// you could also add setters if you needed to modify their values from the presenter
		string Text1 { get; } 
		string Text2 { get; }
		
		// provide a way to bubble up validation errors to the UI
		string ErrorMessage { get; set; }
	}
