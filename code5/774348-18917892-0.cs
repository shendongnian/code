            //The install time was 12:20 PM
            long rawTime = 13024081249872950;
            //Subtract the amount of seconds from 1601 to 1970.
            long convertedTime = (rawTime - 11644473600000000);
            //Devide by 1000000 to convert the remaining time to seconds.
            convertedTime = convertedTime / 1000000;
            //Set up a date at the traditional starting point for unix time.
            DateTime normalDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //Add the seconds we calculated above.
            DateTime googleDate = normalDate.AddSeconds(convertedTime);
            //Finally we have the date.
            System.Diagnostics.Debug.WriteLine("Final Date: " + googleDate.ToString());
