        public async static void Register()
        {
            Debug.WriteLine("Registering geofence bg task");
            if (!IsTaskRegistered())
            {
                var result = await BackgroundExecutionManager.RequestAccessAsync();
                var builder = new BackgroundTaskBuilder();
                builder.Name = TaskName;
                builder.TaskEntryPoint = typeof(BackgroundTask.YourTaskName).FullName;
                builder.SetTrigger(new LocationTrigger(LocationTriggerType.Geofence));
                try
                {
                    builder.Register();
                    Debug.WriteLine("GeoFence Task Registered");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("GeoFence Task Failed : " + ex.Message.ToString());
                }
            }
            else { }
        }
