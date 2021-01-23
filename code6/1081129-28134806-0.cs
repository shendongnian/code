    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    public class Car {
        // C# 6 finally allows read-only autoprops. Yay!
        public int Id { get; }
        public string Make { get; set; }
    
        public Car(int id, string make)
        {
            this.Id = id;
            this.Make = make;
        }
    
        public override string ToString() {
            return Id + "." + Make;
        }
    }
    
    class Test
    {
        static void Main()
        {
            var cars = new List<Car>
            {
                new Car(10, "Ford"),
                new Car(20, "Nissan"),
                new Car(45, "Rolls-Royce")
            };
            
            var listBox = new ListBox
            {
                DataSource = cars,
                DisplayMember = "Id",
                Dock = DockStyle.Fill
            };
           
            var form = new Form
            { 
                Controls = { listBox }
            };
            Application.Run(form);
        }
    }
