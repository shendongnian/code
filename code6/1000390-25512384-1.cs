    public abstract class MyBase
    {
        public static string GetData()
        {
            return "BASE STUFF";
        }
    }
    public class MyDerivedA : MyBase
    {
        protected const string MySpecialData = "AAAAAA";
        public new static string GetData()
        {
            return MyBase.GetData() + MySpecialData;
        }
    }
    public class MyDerivedB : MyBase
    {
        protected const string MySpecialData = "BBBBBBB";
        public new static string GetData()
        {
            return MyBase.GetData() + MySpecialData;
        }
    }
 
