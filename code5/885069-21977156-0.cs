    public class DD : Dictionary<string,Dictionary<int,myClass>>
    {
    }
    DD d = new DD();
    d.Add("key", new Dictionary<int,myClass>());
