    public void Colision()
    {
        foreach (BoundingBox BB_map in Map_BB)
        {
            if (hero.Intersects(BB_map))
            {
                test = "true";
                break;
            }
            else
                test = "false";
        }
    }
