    public class CustomErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            //the procedure for handling the errors.
            //False is returned because every time we have an exception we want to abort the session.
            return false;
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
        }
    }
