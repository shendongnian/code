    public class IPService
    {
        private static string ip = string.Emtpy;
        public static string GetIP()
        {
            if (string.IsNullOrEmpty(this.ip))
            {
                this.ip = HttpContext.Current.Request.UserHostAddress;
            }
            return this.ip;
        }
    }
