    AppDomain appDomain = AppDomain.CreateDomain("WorkerDomain " + Thread.CurrentThread.Name);
    var domain = (AppDomainWorker)appDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(AppDomainWorker).FullName);
    domain.Executor();
****************************************
    internal class AppDomainWorker
    {
        internal object Executor ()
        {
            // your unit test can run here
        }
    }
