    public class B : ClassA
    {
        public static B Create()
        {
            bool success;
            var result = new B(out success);
            if (success)
                return result;
            // TODO: Dispose result?
            throw new StupidProgrammerException();
        }
    }
