    foreach(var playerCounter in googleQueryList)
    {
       if(mentions.ContainsKey(playerCounter.Name))
       {
            //Update the player here
            var currentCount = mentions[player.Name];
            mentions[player.Name] = currentCount + playerCounter.NumOfMentions;
       }
       else
       {
            //Add the player here
            mentions[player.Name] = playerCounter.NumOfMentions;
       }
    }
