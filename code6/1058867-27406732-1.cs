    Point ballRelativeToBrick1 = new Point(
        ballX - picBrick1.UpperLeft.X,
        ballY - picBrick1.UpperLeft.Y)
    bool collide = 0 < ballRelativeToBrick1.X && ballRelativeToBrick1.X < picBrick1.Width
        && 0 < ballRelativeToBrick.Y && ballRelativeToBrick.Y < picBrick1.Height
