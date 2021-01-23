    public async void SetText(string file)
    {
    	try
    	{	        
    		var text = await FileIO.ReadTextAsync(file);
    		
    		//ReadTextAsync succeeded, set text 
    		Editor.Document.SetText(Windows.UI.Text.TextSetOptions.None, text);
    	}
    	catch (Exception ex)
    	{
    		// error do something
    		throw;
    	}
    }
