    var dictionary = new Dictionary<char, List<string>>();
    foreach (var user in users)
    {
        char letter = user[0];
        if (dictionary.Contains(letter))
            dictionary[letter].Add(user);
        else
        {
            var newList = new List<string>();
            newList.Add(user);
            dictionary.Add(letter, newList);
        }
    }
