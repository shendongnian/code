    class Animal {      
        public void Eat() { }
    }
    
    class Human : Animal {     
        public void Talk() { }
    }
    
    Animal a1 = new Human();
    
    Human b1 = new Animal();
