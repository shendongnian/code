    public class Class1
    {
        // Return list if you need list functionality, otherwise enumerable will do
        public IEnumerable<Policy> DoSomething()
        {
            using (var context = new CRMContext())
            {
                 return context.Policies.Where(p => p.new_RenewalDate == 
                                DateTime.Today.AddDays(60).Date).ToList();
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Class1 instance = new Class1();
            foreach (var item in instance.DoSomething())
            {
                // Do work on the item here
            }
        }
    }
