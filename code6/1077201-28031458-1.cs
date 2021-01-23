    //Get information you need from UserPrincipal..
    var matchingUsers = results.Where(p => p.DisplayName.ToLower() == "bob");
    foreach (var matchedUser in matchingUsers)
    {	
      string telephone = matchedUser.VoiceTelephoneNumber;
      string email = matchedUser.EmailAddress;
      var directoryEntry = matchedUser.GetUNderlyingObject() as DirectoryEntry;
      string manager = directoryEntry.Properties["manager"] as string;
    }
    		
				
