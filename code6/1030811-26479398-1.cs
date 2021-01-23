        public static void ProcessNotification([QueueTrigger("%notificationsQueueKey%")] string item)
        {
            using(var n = _kernel.Get<INotifications>())
            {
               n.Process(item);
            }
        }
