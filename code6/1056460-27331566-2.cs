    class velocity() : ICloneable
    {
        #region ICloneable Members
        public object Clone()
        {
            newVelocity = new Velocity();
            newVelocity .Magnitude = this.Magnitude;
            // ...
            return newVelocity ;
        }
        #endregion
    }
