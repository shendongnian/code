    public interface ICar : IAggregateRoot<int>
    {
        int Key { get; }
        IEnumerable<IDoor> Doors { get; }
        SetDoors(IEnumerable<IDoor> doors);
    }
    public class Car : ICar
    {
        //take a look here, it's internal
        internal IList<IDoor> Doors { get; set;}
        public int Key { get; set; }
        public IEnumerable<IDoor> Doors { get { return Doors; } }
        
        //aggregate root always controls aggregate invariants
        public SetDoors(IEnumerable<IDoor> doors)
        {
            if (doors.Count() != 2 || doors.Count() != 4)
                throw new ApplicationException();
            Doors = doors.ToList();
        }
    }
       
    interface IDoor { }
    
    class Door : IDoor { }
    
    //generic interface with IAggregateRoot constraint
    interface ICarFactory
    {
        ICar CreateCar(int doorsCount)
    }
    public class CarFactory : ICarFactory
    {
        public ICar CreateCar(int doorsCount) 
        {
            if (doorsCount != 2 && doorsCount != 4)
                throw new ApplicationException();
            var car = new Car();
            car.Key = 1;
            
            car.Doors = new List<IDoor>();
            car.Doors.Add(new Door());
            //now car is inconsistent as it holds just one door
            car.Doors.Add(new Door());
            //now car is consistent
            return car;
         }
     } 
