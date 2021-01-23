        class Program
        {
        static void Main(string[] args)
        {
            ModelBase sp = new SpecificModel2();
            TestIt(ref sp);
        }
        public static bool TestIt(ref ModelBase BaseModel)
        {
            BaseModel.UserID = 10;
            BaseModel.UserName = "Evan";
            return true;
        }
    }
    public abstract class ModelBase
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
    public class SpecificModel : ModelBase
    {
        public int specificInt { get; set; }
        public string specificString { get; set; }
    }
    public class SpecificModel2 : ModelBase
    {
        public int specificInt { get; set; }
        public string specificString { get; set; }
    }
    }
