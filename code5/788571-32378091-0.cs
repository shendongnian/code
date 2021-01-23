    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                context.MyImmutableClassObjects.Add(new MyImmutableClass(10));
                context.MyImmutableClassObjects.Add(new MyImmutableClass(20));
                context.SaveChanges();
                var myImmutableClassObjects = context.MyImmutableClassObjects.ToList();
                foreach (var item in myImmutableClassObjects)
                {
                    Console.WriteLine(item.MyImmutableProperty);
                }
            }
            Console.ReadKey();
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyImmutableClass> MyImmutableClassObjects { get; set; }
    }
    public class MyImmutableClass
    {
        [Key]
        public int Key { get; private set; }
        public int MyImmutableProperty { get; private set; }
        private MyImmutableClass()
        {
        }
        public MyImmutableClass(int myImmutableProperty)
        {
            MyImmutableProperty = myImmutableProperty;
        }
    }
