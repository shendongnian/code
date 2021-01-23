    public class DeviceInfoAdapter : IMyDeviceInfo 
    {
        private BluetoothDeviceInfo m_theRealStuff;
        // Allow yourself to bypass the abstraction to 
        // get down to the real object, because it may 
        // just be unavoidable in some cases.
        // You may also mark it [Obsolete] or comment it out 
        // until you encounter a real need for it.
        internal BluetoothDeviceInfo TheRealStuff
        {
            get { return m_theRealStuff; }
        }
        // Constructor. If the real stuff has been created by someone else.
        public DeviceInfoAdapter(BluetoothDeviceInfo theRealStuff)
        {
            m_theRealStuff = theRealStuff;
        }
        // Constructor. A knock-off copy of the real stuff constructor.
        public DeviceInfoAdapter(BluetoothAddress address)
        {
            m_theRealStuff = new BluetoothDeviceInfo(address);
        }
        // Imitate all properties and methods on the real stuff.
        public bool Authenticated
        { 
            get 
            { 
                return m_theRealStuff.Authenticated; 
            }
        }
        // ... 
        // Basically, for every publicly-accessible method or property, 
        // you just call the real stuff.
    }
