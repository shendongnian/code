    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Define the Car class
        public class Car 
        {
            public string Name = string.Empty;
        }
        // private variable to hold the current Car value
        private Car _car = null;
        // Public form property that you can run code when either the get or set is called
        public Car car
        {
            get
            {
                return _car;
            }
            set
            {
                _car = value;
                if (_car == null)
                    MessageBox.Show(this, "Run code here when car is set to null", "Car is set to null");
                else
                    MessageBox.Show(this, "Run code here: the cars name is: '" + _car.Name + "'", "Car is set to a value");
            }
        }
        private void SomeFunction()
        {
            Car MyCar = new Car();
            MyCar.Name = "HotRod";
            // This will fire the car setter property
            this.car = MyCar;
        }
    }
