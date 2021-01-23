    // Mobile entity
    public class d_class1: Entity
    {
        // ...stuff...
        public void MoveToPosition(Position pos)
        {
            TweenPosition(_currPosition, pos, movementSpeed);
        }
    }
    // Immobile entity
    public class d_class2: Entity
    {
        // ...stuff...
        public void MoveToPosition(Position pos)
        {
            // Do nothing
        }
    }
    
