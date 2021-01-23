    var newXPos = (int)(xPos + car.Width / 2.0 + Math.Cos(Math.Atan2(-car.Height / 2, -car.Width / 2)
        + angle / 180.0 * Math.PI) * -car.Width / 2.0);
    var newYPos = (int)(yPos + car.Height / 2.0 + Math.Sin(Math.Atan2(-car.Height / 2, -car.Width / 2)
        + angle / 180.0 * Math.PI) * -car.Height / 2.0);
    graphics = e.Graphics;
    graphics.RotateTransform(angle);
    graphics.DrawImage(car, newXPos, newYPos, car.Width, car.Height);
