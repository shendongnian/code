    class Car
    {
        public int Id { get; set; }
        public string Make { get; set;  }
        public string Model { get; set; }
        public int Value { get; set; }
    
        public static void Display(params car[] cars)
        {
            int summ=0;
            foreach(var car in cars)
                Console.WriteLine(car.Value);
            foreach (car i in list)
                summ += car.Value;
            Console.WriteLine(summ); 
        } 
    }
