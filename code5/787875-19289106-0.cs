    public class FDPSequence : TableGenerator
    {
        private const Int32 SeedValue = 1048576;
        public override object Generate(ISessionImplementor session, object obj)
        {
            int counter = Convert.ToInt32(base.Generate(session, obj));
            return counter + SeedValue + 1;
        }
    }
