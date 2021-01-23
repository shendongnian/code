    class DrawableObject {
        public bool IsDead { get; set; }
        public int Health { get; set; }
        // ...
        public void GetShot(int amount) {
            Health -= amount;
            if (Health <= 0)
                IsDead = true;
        }
    }
