    public class FailableContract
    {
        public static void Requires(bool condition)
        {
            #if CONTRACTS_FULL
                Contract.Requires(condition);
            #else
                if (!condition) throw new ArgumentException(); //Just go with an argument exception because we haven't been supplied with an exception type.
            #endif
        }
        public static void Requires<TException>(bool condition) where TException : Exception, new()
        {
            #if CONTRACTS_FULL
                Contract.Requires<TException>(condition);
            #else
                if (!condition) throw new TException();
            #endif
        }
    }
