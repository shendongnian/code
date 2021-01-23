    public class Player
    {
        private IWeapon _wielded;
        public Player(string name)
            :this(name, null, null)
        {}
        public Player(string name, IWeapon primary, IWeapon secondary)
        {
            Name = name;
            Primary = _wielded = primary;
            Secondary = secondary;
            Console.WriteLine(string.Format("Player '{0}' spawned", Name));
        }
        public void Switch()
        {
            _wielded = _wielded != Primary ? Primary : Secondary;
        }
        public void Fire()
        {
            if (_wielded != null)
                _wielded.Fire();
        }
        public string Name { get; set; }
        public IWeapon Primary { get; set; }
        public IWeapon Secondary { get; set; }
    }
