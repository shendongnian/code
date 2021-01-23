    class GenericSpaceShip {
        // Mark the base method virtual
        public virtual void Visit(GenericPlanet planet) {
            Console.WriteLine("Generic");
        }
    }
    
    class SpaceShip : GenericSpaceShip {
        // Mark the overriding method as such
        public override void Visit(Planet planet) {
            Console.WriteLine("Specific");
        }
    }
