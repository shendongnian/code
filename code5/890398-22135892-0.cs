    public class Foo
    {
        public Animal GetAnimal()
        {
            return new Dog();
        }
    }
    public class Bar
    {
        public void DoSomething()
        {
            Foo foo = new Foo();
            Animal animal = foo.GetAnimal();
        }
    }
