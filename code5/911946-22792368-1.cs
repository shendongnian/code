    public class Car : Base
    {
       public Car()
       {
          _Tab = new TabPage("Car");
          _Tab.BackColor = Color.Red;
        }
    }
    public class Truck : Base
    {
       public Truck()
       {
           _Tab = new TabPage("Truck");
           _Tab.BackColor = Color.Blue;
       }
    }
