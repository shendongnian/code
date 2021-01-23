    // Lets create a date to work with.
    DateTime DT1 = DateTime.Now;
    // Create a holding string, and add the day name, with a comma and then the day.
    string FormattedDatestringThing = DT.ToString("dddd") + ", " + DT1.Day.ToString());
    // Now lets add the "st", "nd", "rd" or "th" depending on the day value.
    switch (DT1.Day)
    {
        case 1:
        case 21:
        case 31:
            FormattedDatestringThing += "st";  // So if it's 1, 21 or 31 then add "st".
            break;
        case 2:
        case 22:
            FormattedDatestringThing += "nd";  // If it's 2 or 22 then add "nd".
            break;
        case 3:
        case 23:
            FormattedDatestringThing += "rd";  // If it's 3 or 23 then add "rd".
            break;
        default:
            FormattedDatestringThing += "th";  // Otherwise write out "th".
            break;
    }
    // Finaly add the year to the string and we are done.
    FormattedDatestringThing += " " + DT1.ToString("yyyy"));  
