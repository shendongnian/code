        public class GlobalErrorHanler: IErrorHandler 
        {
            //to use log4net you have to have a proper configuration in you web/app.config
            private static readonly ILog Logger = LogManager.GetLogger(typeof (GlobalErrorHandler));
            public bool HandleError(Exception error)
            {
                //if you host your app on IIS you have to log using log4net for example
                Logger.Error("Error occurred on the service side", error);
                //Console.WriteLine(error.Message); 
                //Console.WriteLine(error.StackTrace);
                return false;
            }
            public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
            {
                //you can provide you fault exception here
            }
        }
