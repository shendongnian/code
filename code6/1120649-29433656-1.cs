    static void Main(string[] args)
        {
            Audi _newCar = new Audi() { Mileage = 10 };
            Car myCar = _newCar;
    
            // Using Reflection
            var propInfo = myCar.GetType().GetProperty("Mileage");
            if (propInfo != null)
            {
                Console.WriteLine(propInfo.GetValue(myCar));
            }
            // Using dynamic
            dynamic myCarDyn = myCar;
            Console.WriteLine(myCarDyn.Mileage);
        }
