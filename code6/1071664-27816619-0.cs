    class SpellBase
    {
        public string Name { get; protected set; } // all spells have to have name
        public virtual void Animate() { ... } // abstract?
    }
