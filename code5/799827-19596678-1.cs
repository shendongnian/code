        // Initial check...
        position = userString.IndexOf(userSubString);
        if(position == -1)
        {
            Console.WriteLine("Your sub-string was not found in your string.\n");
            return;
        }
        // Save the found position and enter the loop
        subStringPositions = Convert.ToString(position) + ", ";
        while (position < userString.Length)
        {
            // Search starting from the following character after the previous found substring
            position = userString.IndexOf(userSubString, position + 1);
            subStringPositions += Convert.ToString(position) + ", ";
        }
 
