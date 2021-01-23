    class House
    {
        public int Number = 25;
    }
    class Car
    {
        public double Price = 50000;
    }
    class Fruit
    {
        public string Name = "Apple";
    }
    class Student
    {
        public int jmbg { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
    }
    class Computer
    {
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public Computer(string cpu, string gpu)
        {
            Cpu = cpu;
            Gpu = gpu;
        }
    }
