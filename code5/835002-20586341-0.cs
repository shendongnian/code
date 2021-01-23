    public ClothedSamurai : Samurai
    {
        readonly IDress dress;
        public ClothedSamurai(IWeapon weapon, IDress dress) : base(weapon)
        {
            this.dress = dress;
        }    
    
        public void Wear()
        {
            //whatever this does
        }    
    }
