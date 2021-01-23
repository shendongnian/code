    var newPets = pets.ToList();
    for (var i = 0; i < newPets.Count; i++)
    {
        if (newPets[i] == null) continue;
        var price = newPets[i].Price;
        for (var j = i + 1; j < newPets.Count; j++)
        {
            if (newPets[j].Price == price) newPets[j] = null;
        }
    }
