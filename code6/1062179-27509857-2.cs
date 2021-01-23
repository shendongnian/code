    public class ToTest
    {
        public static ISystemWrapper SysWrapper = new SystemWrapper();
        public static string GetComputername()
        {
            try
            {
                return SysWrapper.MachineName();
            }
            catch
            {
                return string.Empty; // make sure this never ever fails
            }
        }
    }
