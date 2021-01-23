    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Windows.Forms.Form a = new System.Windows.Forms.Form();
            Console.WriteLine(a.GetType().DistanceToBase());
            Console.WriteLine(a.GetType().PathToBase());
        }
    }
    public static class Extensions
    {
        public static int DistanceToBase(this Type ob)
        {
            if (ob.BaseType == null)
            {
                return 0;
            }
            else return 1 + ob.BaseType.DistanceToBase();
        }
        public static string PathToBase(this Type ob)
        {
            if (ob.BaseType == null)
            {
                return ob.Name;
            }
            return ob.Name + "->" + ob.BaseType.PathToBase();
        }
    }
