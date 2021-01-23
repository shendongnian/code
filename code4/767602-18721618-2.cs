    // I assume that you know how to write the GetUsersSortedByName method
    IList<User> sortedUsers = GetUsersSortedByName();
    char? lastSeenFirstLetter = null;
    // The loop below assumes that there are no users with empty names
    foreach (User u in sortedUsers) {
        if (u.Name[0] != lastSeenFirstLetter) {
            Console.WriteLine("==== Header: users with names in {0}", u.Name[0]);
            lastSeenFirstLetter = u.Name[0];
        }
        Console.WriteLine(u); // Finally, display the user
    }
