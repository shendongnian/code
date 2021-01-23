    public class MProcess
    {
        public static explicit operator MProcess(Process proc)
        {
            return new MProcess(proc);
        }
    }
