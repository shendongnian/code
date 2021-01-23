        public class GlobalErrorHanler: IErrorHandler 
        {
            public bool HandleError(Exception error)
            {
                //if you host your app on IIS you have to log using log4net for example
                Console.WriteLine(error.Message); 
                Console.WriteLine(error.StackTrace);
                return false;
            }
            public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
            {
                //if you host your app on IIS you have to log using log4net for example
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
            }
        }
