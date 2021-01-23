    parseUser = ParseUser.CurrentUser;
    characterData = parseUser.Get<ParseObject>("characterData");
    characterData.FetchIfNeededAsync().ContinueWith(t => {
    	hitPoints = characterData.Get<float>("hitPoints");
    	strength = characterData.Get<float>("strength");
    });
