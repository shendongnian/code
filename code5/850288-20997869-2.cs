    public abstract class Base
    {
        public abstract int GetInt();
    }
    public class Der:Base
    {
        int g = 5;
        public override int GetInt()
        {
            return g+2;
        }
    }
    public class Der2 : Base
    {
        int i = 10;
        public override int GetInt()
        {
            return i+17;
        }
    }
    ....
    var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
    Base b = new Der()
    string json = JsonConvert.SerializeObject(b, jset);
    ....
    Base c = (Base)JsonConvert.DeserializeObject(json, jset);
