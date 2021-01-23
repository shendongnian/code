    public class Fido
    {
        public void foo(Process proc, Options options)
        {
            if (options == Options.Time)
            {
                //Do time work
            }
            else if (options == Options.Priority)
            {
                //Do priority work
            }
        }
    }
    public enum Options
    {
        Time,
        Priority
    }
