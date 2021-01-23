    public abstract class Animal {
        private string _name;
        //This is syntax for declaring a property
        //properties are publicly accessible pieces of data that control access to a basic
        // field (variable).
        public string Name {get { return _name;} set {_name = value;} }
        //This is a method that must be overridden by non-abstract classes.
        public abstract void Examine();
    }
    public class Cat : Animal {
        public override void Examine() {
            Console.WriteLine(String.Concat("This is a cat.  It's name is ", this.Name, "."));
        }
    }
    public Class Dog : Animal {
        public override void Examine() {
            Console.WriteLine(String.Concat("This is a dog.  It's name is ", this.Name, "."));
        }
    }
    //In some runnable code elsewhere like a console application:
    Animal cat = new Cat();
    Animal dog = new Dog();
    cat.Examine();
    dog.Examine();
