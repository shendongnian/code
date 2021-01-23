    using System.Collections.ObjectModel;
    using System.Data;
    namespace SOWPF
    {
        public class CarViewModel
        {
            public ObservableCollection<Car> dt { get; set; }
            public void LoadCars()
            {
                dt = new ObservableCollection<Car>();
                Car ferrari = new Car("Ferrari", "Front-Wheel");
                Car mercedes = new Car("Mercedes", "Rear-Wheel");
                dt.Add(ferrari);
                dt.Add(mercedes);
            }
        }
        public class Car
        {
            public Car(string name, string drive)
            {
                Name = name;
                Drive = drive;
            }
            public string Name { get; set; }
            public string Drive { get; set; }
        }
    }
         
