    public class Key
    {
        public virtual Key GetBaseKey()
        { return null; }
    }
    
    public class CarKey : Key
    {
        public override Key GetBaseKey()
        { return new Key(this.Name); }
    }
