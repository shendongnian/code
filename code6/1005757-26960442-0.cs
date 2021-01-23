    private void PushGCM(List<string> registerationIds)
        {
            var push = new PushBroker();
            push.RegisterGcmService(new GcmPushChannelSettings("applicationID"));
            GcmNotification gcmNotifiction = new GcmNotification();
            gcmNotifiction.RegistrationIds.AddRange(registerationIds);
            gcmNotifiction.WithJson(@"{""alert"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}");
            //Stop and wait for the queues to drains
            push.StopAllServices();
        }
