    public class SumObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public abstract class AbstractClass
    {
        protected SumObject SumProperty { get; private set; }
        protected AbstractClass()
        {
            SetupSumObjecInAbstractClass();
            DoWorkInChildClass();
        }
        protected void SetupSumObjecInAbstractClass()
        {
            SumProperty = new SumObject() { ID = 1, Name = "James Dean" };
        }
        protected abstract void DoWorkInChildClass();
    }
    public class ChildClass : AbstractClass
    {
        protected override void DoWorkInChildClass()
        {
            if (SumProperty == null)
                throw new Exception("Dang!");
            Console.WriteLine(string.Format("My Name is: {0}"
                                            , SumProperty.Name));
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var name = new ChildClass();
        }
    }
