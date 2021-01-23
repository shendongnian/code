    public Character (SizeF size, PointF position) : base("character")
    {
         this.Name = CHARACTER_NAME;
         this.Size = size;
         this.Position = position;
         this.PhysicsBody = SKPhysicsBody.BodyWithRectangleOfSize (this.Size);
         this.PhysicsBody.AffectedByGravity = true;
         this.PhysicsBody.AllowsRotation = false;
         this.PhysicsBody.Mass = 1.0f;
         this.PhysicsBody.CategoryBitMask = COLLISION_BITS.Character;
         this.PhysicsBody.CollisionBitMask = COLLISION_BITS.Character;
         this.PhysicsBody.ContactTestBitMask = COLLISION_BITS.PowerUp;
    }
