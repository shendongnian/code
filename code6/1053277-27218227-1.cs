    static void Main()
    {
        var car = new Car(6000, "audi");
        car._OnSell += Car_OnSell;
        car.Sell(string.Format("Selling the car: {0}", car.ModelName));
    }
    public static void Car_OnSell(string message)
    {
        Console.WriteLine(message);
    }
    public class Car
    {
        public int Price { get; set; }
        public string ModelName { get; set; }
        public Boolean Sold { get; set; }
        public delegate void SellEventHandler(string str);
        public event SellEventHandler _OnSell;
        public void Sell(string str)
        {
            if (_OnSell != null)
            {
                _OnSell(str);
            }
            this.Sold = true;
        }
        public Car(int price, string modelname)
        {
            Price = price;
            ModelName = modelname;
            Sold = false;
        }
    }
