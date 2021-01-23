    public abstract class Animal {
        private string _name;
        
        //Constructor is called when you use the 'new' keyword to instantiate an instance of a type that derives from Animal
        protected Animal() {
            //Avoids null references unless someone overrides the property setter, for this example, it's safe enough
            _name = string.Empty;
        }
        //This is syntax for declaring a property
        //properties are publicly accessible pieces of data that control access to a basic
        // field (variable).
        // It allows you to apply logic to the field it wraps.
        // In this example, the field cannot be set to a null or empty string (except by the constructor, which bypasses the property.
        public virtual string Name {
            get { 
                return _name;
            } set {
                if(!String.IsNullOrWhiteSpace(value)) {
                    _name = value;
                }
            }
        } // end property Name
        //This is a method that must be overridden by any derived type that is not abstract.
        public abstract void Examine();
    }
    public class Cat : Animal {
        public Cat : base() {}
        public override void Examine() {
            Console.WriteLine(String.Concat("This is a cat.  It's name is ", this.Name, "."));
        }
    }
    public Class Dog : Animal {
        public Dog() : base() {}
        public override void Examine() {
            Console.WriteLine(String.Concat("This is a dog.  It's name is ", this.Name, "."));
        }
    }
    //In some runnable code elsewhere like a console application:
    Animal cat = new Cat() {Name = "Mittens"};
    Animal dog = new Dog() {Name = "Fido"};
    cat.Examine();
    dog.Examine();
