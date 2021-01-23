    var keysToBeRmoved =Users
        .Where(r => r.Value.EmailAddress == "email" && r.Value.Alias == "alias")
        .Select(r => r.Key)
        .ToList();
    foreach (var key in keysToBeRmoved)
    {
        Users.Remove(key);
    }
