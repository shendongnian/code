    interface IOnDeviceControllerListener
    {
            void OnError(ControllerError.Error error, String message);
            void OnRead(MobileServiceList<Device> devices);
            void OnInsert(Device device);
    }
