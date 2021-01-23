This is the loop in question, as well as the one after it. In the declarations, change all instances of i to x (or whatever) as I have shown above.
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
