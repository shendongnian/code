    private void SetupPowerUp(SizeF size, PointF position)
    {
        this.Size = size;
        this.Position = position;
        this.PhysicsBody = SKPhysicsBody.BodyWithRectangleOfSize (this.Size);
        this.PhysicsBody.AffectedByGravity = false;
        this.PhysicsBody.AllowsRotation = false;
        this.PhysicsBody.Mass = 0f;
        this.PhysicsBody.CategoryBitMask = COLLISION_BITS.PowerUp;
        this.PhysicsBody.CollisionBitMask = COLLISION_BITS.PowerUp;
        this.PhysicsBody.ContactTestBitMask = COLLISION_BITS.Character;
    }
