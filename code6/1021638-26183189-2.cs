    interface IAnimal
    {
        int DoSomething();
    }
    class Bobcat implements IAnimal
    {
        private IAnimal _a;
        public Bobcat(IAnimal a) // inject the dependency through the constructor
        {
            this._a = a;
        }
        public int DoSomething() // implement IAnimal
        {
            return _a.DoSomething(); // delegate to _a
        }
    }
