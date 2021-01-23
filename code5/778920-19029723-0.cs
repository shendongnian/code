    public class Character : ICloneable
    {
        // Character data
        //Implement Clone Method
    }
    
    public class StatusEffect
    {
        private Character target;
        private Character originator;
    
        public void Init(Character _Target, Character _Originator)
        {
            target = _Target.Clone()
            originator = _Originator.Clone();
        }
