    var newPosX = (int)(posX + car.Width / 2.0 + Math.Cos(Math.Atan2(-car.Height / 2, -car.Width / 2)
        + angle / 180.0 * Math.PI) * -car.Width / 2.0);
    var newPosX = (int)(posY + car.Height / 2.0 + Math.Sin(Math.Atan2(-car.Height / 2, -car.Width / 2)
        + angle / 180.0 * Math.PI) * -car.Height / 2.0);
    graphics = e.Graphics;
    graphics.RotateTransform(angle);
    graphics.DrawImage(car, newPosX, newPosX, car.Width, car.Height);
