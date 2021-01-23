        public class MyService : ServiceBase
        {
            public MyService()
            {
                // configure the service
                this.ServiceName = "MyService";
            }
            // override the events you want
            protected override void OnStart(string[] args)
            {
                base.OnStart(args);
            }
            protected override void OnStop()
            {
                base.OnStop();
            }
        }
