    //sort this list by username ascending
    IList<String[]> usersByUsername = users.OrderBy(user => user[0]).ToList();
    // display the newly ordered list
    for (int i = 0; i <= users.Count; i++)
    {
        Console.WriteLine(string.Join(", ", usersByUsername[i]));
    }
