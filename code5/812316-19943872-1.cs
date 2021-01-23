    while (!sr.EndOfStream)
    {
        player[i] = new student();
        players[i].lastname = sr.ReadLine();
        players[i].firstname = sr.ReadLine();
        players[i].likes = sr.ReadLine();
        i++;
    }
