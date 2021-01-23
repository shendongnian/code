    namespace Thing
    
    [KnownType(typeof(Tomato))]
    public abstract class Fruit : Vegetable { }
    
    public sealed class Tomato : Fruit{}
    
    namespace Thing
    
    [KnownType(typeof(Tomato))]
    public abstract class Vegetable {}
    
    public sealed class Carrot : Vegetable{}
