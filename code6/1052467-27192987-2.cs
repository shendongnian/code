    public class DeviceInterrupt
    {
        IntPtr m_gpio;
        string m_eventName;
        public event EventHandler OnInterrupt;
        public DeviceInterrupt(int port)
        {
            // get a driver handle
            m_gpio = GPIO_Open();
            // generate some unique event name
            m_eventName = "GPIO_evt_" + port;
            // wire up the interrupt
            GpioSetupInterruptPin(m_gpio, port, m_eventName, ...);
            // start a listener
            new Thread(EventListenerProc)
            {
                IsBackground = true,
                Name = "gpio listener"
            }
            .Start();
        }
        public void Dispose()
        {
            // TODO: release the handle
        }
        private void EventListenerProc()
        {
            // create the event with the name we sent to the driver
            var wh = new WaitHandle(false, m_eventName);
            while (true)
            {
                // wait for it to get set by the driver
                if (wh.WaitOne(1000))
                {
                    // we have an interrupt
                    OnInterrupt.Fire(this, EventArgs.Empty);
                }
            }
        }
    }
