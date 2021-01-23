    public abstract class AbstractFactory
    {
        public abstract TCake CreateCake<TCake>() where TCake : AbstractCake, new();
        public abstract AbstractBox CreateBox();
    }
    ...
    var cake = str.GetFactory().CreateCake<ChocolateCake>();
