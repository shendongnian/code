    bool isCollision = rectball1.Intersects(rectSprite);
    if (isCollision)
    {
        s.CollisionWith(ball1);
        ball1.ColisionWith(s);
    }
