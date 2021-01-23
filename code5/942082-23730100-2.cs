        public Spell Hang<T>(InvocationInfo details) where T: Spell
        {
            if(details.SpellCaster.Energy < T.EnergyCost) 
                throw new InsufficientEnergyException();
            
            // ...
        }
        var spell = SpellFactory.Hang<Rotation>();
