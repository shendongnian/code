 private NameValueCollection LoadQuartzProperties()
{
            var NameValueCollection = new NameValueCollection();
            NameValueCollection.Add("quartz.scheduler.instanceName", "HomeScheduler");
            NameValueCollection.Add("quartz.scheduler.instanceId", "Instance");
            NameValueCollection.Add("quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz");
            NameValueCollection.Add("quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.MySQLDelegate, Quartz");
            NameValueCollection.Add("quartz.jobStore.useProperties", "false");
            NameValueCollection.Add("quartz.jobStore.dataSource", "Home");
            NameValueCollection.Add("quartz.jobStore.tablePrefix", "QRTZ_");
            NameValueCollection.Add("quartz.dataSource.Home.provider", "MySql");
            NameValueCollection.Add("quartz.dataSource.Home.connectionString", "server=ser...;database=...;user=...;pwd=...;TreatTinyAsBoolean=false");
            NameValueCollection.Add("quartz.threadPool.threadCount", "50");
            NameValueCollection.Add("quartz.threadPool.threadPriority", "10");
            NameValueCollection.Add("quartz.serializer.type", "json");           
            return NameValueCollection;
}
