      using System; 
       using System; 
        using System.Collections.Generic; 
       using System.Linq; 
      using System.Text;
         namespace Assignment13
        {
         class Car
    {
        int speed = 0;
        double temp =0;
        private int Speed;
        public void setSpeed(int speed)
        {
            this.speed = 50;
        }
        public int getSpeed()
        {
            return speed;
        }
        
        private double Temp;
        public void setTemp(double temp)
        {
            this.temp = 70.5;
        }
        public double getTemp()
        {
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car ford = new Car();
            ford.setSpeed(50);
            ford.setTemp(70.5);
            Console.WriteLine("Speed = " + ford.getSpeed());
            Console.WriteLine("Temp = " + ford.getTemp());
            
            Console.Write("Hit any key to close"); Console.ReadKey(true);
        }
    }
}
