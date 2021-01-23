    class Mammal {
        public void Nurse() { /* */ }
    }
    class Dog : Mammal {
        public void ChaseCar() { /* */ }
    }
    class Cat : Mammal {
        public void ClimbTree() { /* */ }
    }
    Mammal mammal = new Cat();
    //  The actual THING that mamal refers to may not be a Dog, 
    //  So the compiler won't let you do this. 
    mammal.ChaseCar();
    //  But C# does let you FIND OUT what you've got:
    if ( mammal is Dog ) {
        var mydog = mammal as Dog;
        mydog.ChaseCar();
    }
