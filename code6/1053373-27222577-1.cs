    public class Attribute<T>
    {
        public int ID {get; set;}
        public string Name { get; set; }
        public T Value { get; set; }
    }
 
    public void SomeMethod()
    {
        var attribute = new Attribute<int>(){ ID = 1, Name = "TheName", Value = 46 };
    }
