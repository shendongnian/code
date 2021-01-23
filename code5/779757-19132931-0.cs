    public class Employee
    {
        public string Name { get; set; }
    }
    public class EvilDeleg
    {
        public EvilDeleg(Action<Employee> act)
        {
            this.act = act;
        }
        Action<Employee> act;
        public void DoSomething(Employee emp)
        {
            Console.WriteLine(emp.Name); // resulting in "First"
            emp.Name = " Evil";
            act(emp);
            Console.WriteLine(emp.Name); // resulting in " Evil Second"
        }
    }
    public class TestStatefulInterface
    {
        public void ConsumeEvilDeleg()
        {
            Employee emp = new Employee();
            EvilDeleg deleg = new EvilDeleg(k => k.Name = k.Name + " Second");
            emp.Name = "First";
            deleg.DoSomething(emp);
            Console.WriteLine(emp.Name); // resulting in " Evil Second"
        }   
    }
