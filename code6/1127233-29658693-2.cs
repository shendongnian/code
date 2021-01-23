    for (int y = 100; y <= 300; y += 50)
    {
        for (int X = 200; x <= 700; x += 50)
        {
            Invader invader = new Invader();
            InvaderList.Add(invader);
            invader.SetXPos(x);
            invader.SetYPos(y);
        }
    }
