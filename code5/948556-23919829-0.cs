    string[] trackingIDs = {"910236783468367367346738","810236783468367367346738","710236783468367367346738"};
        string finalString = null;
        for(int i = 0; i < trackingIDs.Length; i++)
        {
            finalString = "<tracking userID=ABC trackingID=\"" + trackingIDs[i] + "\" deliveryNotification=false>";
            Console.WriteLine(finalString);
        }
