    void setRandomFlag()
    {
        // a random number generator
        Random R = new Random();
        // a list to keep our used up country numbers
        List<int> usedFlags = new List<int>();
        // the number of countries to chose from:
        int cCount = lstLanden.Items.Count;
        // first index we try
        int rInd = R.Next(cCount );
        // we shall give each button a flag etc..
        foreach (Button btn in abuttons)
        {
            // find an unsed index
            while (usedFlags.Contains(rInd)) {rInd = R.Next(cCount );}
            // store it
            usedFlags.Add(rInd);
            // pull the Country object from the listbox
            Country country = (Country)lstLanden.Items[rInd];
            // use it
            btn.BackgroundImage = Image.FromFile(country.Flag);
            // this is a trick to keep a reference to the country at each button
            // we may need it later or not..
            btn.Tag = country;
        }
    }
