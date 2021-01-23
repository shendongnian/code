    class Program
    {
        static void Main(string[] args)
        {
            System.Web.Script.Serialization.JavaScriptSerializer json = 
                new System.Web.Script.Serialization.JavaScriptSerializer();
            Console.WriteLine(json.Serialize(new Full(true)));
            Console.WriteLine(json.Serialize(new Limited()));
        }
    }
    public abstract class Base
    {
        public String Stuff { get { return "Common things"; } }
    }
    public class Full : Base
    {
        public FullStatus Status { get; set; }
        public Full(bool includestatus)
        {
            if (includestatus)
                Status = new FullStatus();
        }
    }
    public class Limited : Base
    {
        public LimitedStatus Status { get; set; }
        public Limited()
        {
            Status = new LimitedStatus();
        }
    }
    public class FullStatus
    {
        public String Text { get { return "Loads and loads and loads of things"; } }
    }
    public class LimitedStatus
    {
        public String Text { get { return "A few things"; } }
    }
