    using System;
    class Car
    {
        public Car(string name)
        {
            Name = name;
        }
        public bool isEmpty { get; set; }
        public string Name { get; set; }
        public void EmptyOut() { }
    }
    static class Program
    {
        public static Car Car0 = new Car("Car0");
        public static Car Car1 = new Car("Car1");
        public static Car Car2 = new Car("Car2");
        public static Car Car3 = new Car("Car3");
        public static Car Car4 = new Car("Car4");
        public static Car Car5 = new Car("Car5");
        public static Car Car6 = new Car("Car6");
        public static Car Car7 = new Car("Car7");
        public static Car Car8 = new Car("Car8");
        public static Car Car9 = new Car("Car9");
        static void Main()
        {
            var type = typeof(Program);
            for (int i = 0; i <= 9; i++)
            {
                var field = type.GetField("Car" + i);
                var temp = (Car)field.GetValue(null);
                if (temp.isEmpty)
                {
                    // Do stuff.
                    break;
                }
                else
                {
                    temp.EmptyOut();
                }
            }
        }
    }
