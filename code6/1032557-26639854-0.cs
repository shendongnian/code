    for (int gy = j - 1; gy <= j + 1; gy++)
    {
        if (gy >= 0 && gy < gems.GetLength(0))
        {
            for (int gx = i; gx >= 0; gx--)
            {
                if (gy == j)
                {
                    gems[gx, gy].MoveTowardsPosition(gems[gy, gx].Position.Swap() + new Vector2(0, -70), gemMoveSpeed * 1.8f, true, softMove: true);
                }
                else gems[gx, gy].MoveTowardsPosition(gems[gy, gx].Position.Swap() + new Vector2(0, -45), gemMoveSpeed * 1.8f, true, softMove: true);
                moveTimer = 0;
            }
        }
    }
