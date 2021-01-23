    public interface IManager<out T> where T : Asset { }
    public class Test
    {
        public IManager<Asset> Manager;
    }
