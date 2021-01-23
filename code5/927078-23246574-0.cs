    for (int i = 0; i < RocketsLeft.Count; i++)
        {
            RocketsRight[i] = new Rectangle(RocketsRight[i].X + 3, RocketsRight[i].Y, RocketsRight[i].Width, RocketsRight[i].Height);
        }
        for (int i = 0; i < RocketsLeft.Count; i++)
        {
            RocketsLeft[i] = new Rectangle(RocketsLeft[i].X - 3, RocketsLeft[i].Y, RocketsLeft[i].Width, RocketsLeft[i].Height);
        }
