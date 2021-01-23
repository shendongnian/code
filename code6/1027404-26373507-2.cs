    public MoveTo(Creature Creature)
        {
            this.creature = Creature;
        }
    
        public Act()
        {
            creature.MoveTowards(this.creature.ClosestTarget);
        }
