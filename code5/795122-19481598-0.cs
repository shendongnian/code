    class Program
    {
        static void Main(string[] args)
        {
            House h = new House();
            Console.WriteLine("This house has {0} screws", h.FindAll<Screw>().Count());
        }
    
        public interface IHouseComponent
        {
            IHouseComponent Parent { get; }
            IEnumerable<T> FindAll<T>() where T : IHouseComponent;
            IEnumerable<IHouseComponent> Children { get; }
        }
    
        public abstract class HouseComponentBase : IHouseComponent
        {
            private List<IHouseComponent> _children = new List<IHouseComponent>();
            protected HouseComponentBase(IHouseComponent parent)
            {
                Parent = parent;
            }
    
            protected void AddChild(IHouseComponent component)
            {
                _children.Add(component);
            }
    
            public IHouseComponent Parent { get; private set; }
    
            public IEnumerable<IHouseComponent> Children { get { return _children; } }
    
            public IEnumerable<T> FindAll<T>() where T : IHouseComponent
            {
                var list = new List<T>();
                list.AddRange(_children.OfType<T>()); // add appropriate components in direct children
                foreach (var node in _children)
                    list.AddRange(node.FindAll<T>()); // then add all components that are part of descendants               
    
                return list;
            }
        }
    
        public class House : HouseComponentBase
        {
            public House()
                : base(null)
            {
                // two room house
                AddChild(new Room(this));
                AddChild(new Room(this));
            }
        }
    
        public class Room : HouseComponentBase
        {
            public Room(House parent)
                : base(parent)
            {
                // 4 walls per room - no ceiling or floor
                AddChild(new Wall(this));
                AddChild(new Wall(this));
                AddChild(new Wall(this));
                AddChild(new Wall(this));
            }
        }
    
        public class Wall : HouseComponentBase
        {
            public Wall(Room parent)
                : base(parent)
            {
                for (int i = 0; i < 64; i++)
                    AddChild(new Screw(this));// each wall has 64 screws
            }
        }
    
        public class Screw : HouseComponentBase
        {
            public Screw(IHouseComponent parent) // a screw can be part of any component
                : base(parent)
            {
            }
        }
    }
