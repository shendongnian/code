        public interface ICastable()
        {
            bool ValidateTarget();
            // ICastable will require implementors to define Cast;
            // forcing a descendant (or the ancestor, I suppose) to
            // provide the details of how to cast that spell.  The parameter
            // is also a type that you control for spell-casting information
            void Cast(InvocationInfo info);
        }
        // really common info needed to cast a spell
        public class InvocationInfo
        {
            TargetableEntity Target;
            ControllableEntity SpellCaster;
            List<SpellRegents> ReagentsChosen;
            MoonPhases MoonPhase;
            bool IsMercuryInRetrograde;
        }
        // base spell class
        public class Spell
        {
            public string Name { get; set; }
            public int EnergyCost { get; set; }
        }
        // actual castable spell
        public class MagicMissile : Spell, ICastable
        {
            public void Cast(InvocationInfo details)
            {
                details.SpellCaster.SpendMana(this.EnergyCost);
                
                if (details.Target.Location.DistanceFrom(details.SpellCaster) > this.Range)
                {
                    details.SpellCaster.SendMessage(Messages.OutOfRange);
                    return;
                }
                // ...
            }
        }
