    namespace PROJ.admin 
    {
        public static class NewClass
        {
            public void ProcessRequest(HttpContext context)
            {
                bool ch = ExceptionDatesUpdateService.IsServiceRunning();
            }
        }
    }
