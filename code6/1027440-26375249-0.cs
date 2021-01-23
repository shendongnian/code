    class GalaxyFactory: AbstractFactory
      {
        public override Galaxy CreateProductA()
        {
            return spiral();
        }
        public override SolarSystem CreateProductB()
        {
            return null;
        }
      }
