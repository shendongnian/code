    interface IBase
    {
        int Member { get; }
    }
    interface IDerived : IBase
    {
    }
    class Animal : IBase
    {
        int IBase.Member
        {
            get { return 10; }
        }
    }
    class Elephant : Animal, IDerived  // try ": Animal, IBase, IDerived"        ...        ...        ...        also try ": Animal, IBase"; try ": Animal"
    {
        public int Member
        {
            get { return 20; }
        }
    }
    static class Test
    {
        static void Main()
        {
            IBase elephantAsIBase = new Elephant();
            int readMember = elephantAsIBase.Member;
            Console.WriteLine(readMember);
        }
    }
