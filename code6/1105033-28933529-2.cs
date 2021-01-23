    public class B : IFoo
    {
        public int Bar { get { return 2; } }
        int IFoo.Bar { get { return 1; } }
    }
