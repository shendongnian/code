    class Storage
    {
        internal event Action NumberUpdated;
        {
            set
            {
                lock(LockNumber)
                {
                    _number = value;
                    if( NumberUpdated != null )
                       NumberUpdated();
                    Monitor.Pulse(LockNumber);
                    Monitor.Wait(LockNumber);
                }
            }
        }
    }
    class Printer
    {
        private AutoResetEvent propertyUpdated;
        //Other code omitted for brevity's sake
        public Printer( Storage storage )
        {
            propertyUpdated = new AutoResetEvent();
            storage.NumberUpdated += OnStorageNumberUpdated;
            t1.Start();
        }
        private void OnStorageNumberUpdated(){
           propertyUpdated.Set();
        }
        public static void Print()
        {
            while (true)
            {
                propertyUpdated.WaitOne();
                Console.WriteLine("Number is " + Storage.Number);
            }
        }
    }
