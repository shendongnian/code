    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {                  
            while (true)
            {
                CloudQueueMessage queuemessage = queuestorage.GetMessage(queue name)
                if(queueMessage.exist && queueMessage insertion time < 10 am today)
                {
                    if (DateTime.Now.Hour >= 10)
                    {
                        //Do Specific timer Job();
                        //Delete the queue message and insert new one for the task next day.
                    }
                }
                //Do Normal Worker process();
                Thread.Sleep(TimeSpan.FromMinutes(1));
            }
        }
    }
