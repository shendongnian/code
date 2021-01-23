    Point origin = sprite.Position; // Assumes some sprite object with a position.
    Point dest = new Point(200,344); // Destination.
    Vector totalTranslation = new Vector(dest.X - origin.X, dest.Y - origin.Y);
    Vector perSecond = totalTranslation / 60; // assuming takes a minute to move.
    Vector distanceMoved = perSecond * 4; // distance moved after 4 seconds.
    
    Point newPosition = new Point(origin.X + distanceMoved.X, origin.Y + distanceMoved.Y);
    sprite.Position = newPosition; // Or using some orchestration class...
    spriteManager.Move(sprite, newPosition); // ...like this.
