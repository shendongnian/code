    Point origin = sprite.Position; // Assumes some sprite object with a position.
    Vector v = new Vector(20, 45);
    Vector perSecond = v / 60; // assuming takes a minute to move.
    Vector distanceMoved = perSecond * 4; // distance moved after 4 seconds.
    
    Point newPosition = new Point(origin.X + distanceMoved.X, origin.Y + distanceMoved.Y);
    sprite.Position = newPosition; // Or using some orchestration class...
    spriteManager.Move(sprite, newPosition); // ...like this.
