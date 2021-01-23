        public static void WithExceptionLogging(Action testToExecute)
        {
            try
            {
                testToExecute();
            }
            catch (Exception e)
            {
                //logging logic goes here
            }
        }
