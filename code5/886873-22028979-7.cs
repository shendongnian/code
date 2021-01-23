Here are the loops in question. In the declarations, change all instances of i to x (or whatever) as I have shown above.
    for (int i = 0; i < rectSpaceInvader.Length; i++)
    {
        if (AlienAlive[i].Equals("Yes"))
            CountAliensAlive = CountAliensAlive + 1;
    }
    for (int i = 0; i < rectSpaceInvader.Length; i++)
    {
        {
            if (AlienAlive[i].Equals("Yes"))
                if (rectSpaceInvader[i].Y + rectSpaceInvader[i].Height > rectSpaceShip.Y)
                    this.Exit();*
        }
    }
They are both contained inside of this one (showing if for reference).
    if (ShipBulletVisible.Equals("Yes"))
    {
        for (int i = 0; i < rectSpaceInvader.Length; i++)
        {
            //code
        }
    }
