    class Velocity() : ICloneable
    {
        #region ICloneable Members
        public object Clone()
        {
            velocity = new Velocity();
            velocity.Magnitude = this.Magnitude;
            // ...
            return velocity;
        }
        #endregion
    }
