    static void Main(string[] args)
            {
                // ...ignore load plugin code
                //
                APlugin p = new Plugin();
                // register event with IPlugin
                p.OnFinish += new OnFinishDelegate(OnFinishHandler);
                p.OnException += new OnExceptionDelegate(OnExceptionHandler);
                // let plugin do its work on a subthread
                Thread t = new Thread(p.Operate);
                t.Start();
                // and then main continue do other work...
            }
            // if plugin throw exception, in the host application will 
            // handle this exception...
            private static void OnExceptionHandler(APlugin p, AMessageEventArgs e)
            {
                // in here will process exception of plugin...
            }
            // if plugin completed its work, it will use OnFinish event to 
            // notify to host application
            private static void OnFinishHandler(APlugin p, AMessageEventArgs e)
            {
                // in here will process completed work event
            }
