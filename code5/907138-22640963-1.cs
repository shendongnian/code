    public class BoolClass
    {
        public static bool operator true(BoolClass instance)
        {
            return true; //Logic goes here
        }
        public static bool operator false(BoolClass instance)
        {
            return true; //Logic goes here
        }
        public void Test()
        {
            BoolClass boolClass = new BoolClass();
            if (boolClass)
            {
                //Do something here
            }
        }
    }
