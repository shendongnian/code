        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (IOException ex)
            {
                if (ex.HResult == -2146233087) // The socket has been shut down
                {
                    NLog.LogManager.GetLogger("OwinExceptionHandler").Trace(ex);
                }
                else
                {
                    throw;
                }
            }
        }
