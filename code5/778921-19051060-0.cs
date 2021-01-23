    public class StatusEffect
    {
        public Character Target { get; private set; }
        public Character Originator { get; private set; }
    
        public StatusEffect Init(Character target, Character originator)
        {
            Target = target.Clone()
            Originator = originator.Clone();
            return this;
        }
    //...
    }    
    
    public CElementTag(CElementTag _Tag)
        {
            i_ID = _Tag.i_ID;
            str_Name = _Tag.str_Name;
            enum_Type = _Tag.enum_Type;
            f_Duration = _Tag.f_Duration;
        
            ar_statusEffects = _Tag.ar_statusEffects.Select(eff => 
                new StatusEffect().Init(eff.Target, eff.Originator)).ToArray();
    
            // ar_statusEffects = new CStatusEffect[_Tag.ar_statusEffects.Length];
            // Array.Copy(_Tag.ar_statusEffects, ar_statusEffects, _Tag.ar_statusEffects.Length);
    
    
        }
