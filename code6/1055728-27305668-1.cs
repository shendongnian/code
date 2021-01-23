    public class ReadParams : UmBase
    {
        public ReadParams(UpdateManager updateManager, int cycleMs = 60000)
            : base(cycleMs, updateManager, "sss")
        {
            Iteration();
        } 
        public override void Iteration()
        {
            try
            {
                // If throw here (A)
                DbParams.Set(); //EXCEPTION IS THROWN INSIDE
            }
            catch (Exception exception)
            {
                // I'll catch here (A) and then throw a new exception
                throw new Exception("Oops!", exception);
            }
        }
    }
    public void Work()
    {
        while (IsProcessing)
        {
            try
            {
                // Exceptions thrown here including the one you 
                // threw in the method Iteration (B)
                Iteration();
            }
            catch (Exception exception)
            {
                // Will be caught here (B)
                Log.Error(exception.Message); //WANT TO HANDLE IT HERE
            }
            finally
            {
                Sleep(100);
            }
        };
    } 
