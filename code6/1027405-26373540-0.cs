    class MoveTo : Routine
    {
        Creature creature;
        Func<Entity> target;
    
        public MoveTo(Creature Creature, Func<Entity> Target)
        {
            this.creature = Creature;
            this.target = Target;
        }
    
        public Act()
        {
            creature.MoveTowards(Target());
        }
    }
