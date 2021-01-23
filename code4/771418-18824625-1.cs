    public class DerivedClass : BaseClass
    {
        public string Property3
        { get; set; }
        public void DoSomething ()
        {
            LoadSomeThing();
        }
        public override void LoadSomeThing ()
        {
            base.LoadSomeThing();
            Console.WriteLine(Property3);
        }
    }
    public class BaseClass {
        public string Property1
        { get; set; }
        public string Property2
        { get; set; }
        public virtual void LoadSomeThing()
        {
            Console.WriteLine(Property1);
            Console.WriteLine(Property2);
        }
    }
