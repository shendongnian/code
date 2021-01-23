    class Projectile 
    {
        protected virtual float DefaultSpeed { get { return 50; } }
        public void Shoot(float? speed = null)
        {
            float actualSpeed = speed ?? DefaultSpeed;
            //Do stuff
        }
    }
    class SaiBlast : Projectile
    {
        protected override float DefaultSpeed { get { return 100; } }
    }
