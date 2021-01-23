	static void InsertNewAlbum()
	{
	    //Variable for user input
	    string albumInput;
	
	    //Ask for the user for details 
	    Console.WriteLine("Enter the Title of the album you would like to store");
	    albumInput = Console.ReadLine();
	
	    //Process the input of the user to make it easier to search later on
	    albumInput = albumInput.ToUpper();
	    albumInput = albumInput.Trim();
	
	    //Find an empty spot within list
	    int nextAvailableSpace = FindSlot(albumInput);
	    if (nextAvailableSpace != -1)
	    {
	        Console.WriteLine(albumInput + " is stored successfully at slot" + nexAvailableSpace + "");
	    }
	    else
	    {
	        //Inform that the usercannot park as the parking space is full
	        Console.WriteLine("Sorry, but there are no available spaces left to store your       album.");
	    }
	    Console.ReadLine();
	}
