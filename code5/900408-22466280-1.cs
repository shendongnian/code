     class Vehicle
     {
        protected int  X{}
        public Vehicle(int x)
        { 
          X= x;
          ++X;
         }
     }
     car = new Car(4);
     Assert.ReturnsFive(car.DoSomething(),5)
