    class Storage
    {
        internal event Action<bool> NumberUpdated;
        {
            set
            {
                lock(LockNumber)
                {
                    _number = value;
                    if( NumberUpdated != null )
                       NumberUpdated( isLastUpdate ); //TODO: Add logic to compute it
                    Monitor.Pulse(LockNumber);
                    Monitor.Wait(LockNumber);
                }
            }
        }
    }
    class Printer
    {
        private AutoResetEvent propertyUpdated;
        private bool keepPrinting;
        //Other code omitted for brevity's sake
        public Printer( Storage storage )
        {
            propertyUpdated = new AutoResetEvent();
            storage.NumberUpdated += OnStorageNumberUpdated;
            keepPrinting = true;
            t1.Start();
        }
        private void OnStorageNumberUpdated( bool isLastUpdate ){
           keepPrinting = !isLastUpdate;
           propertyUpdated.Set();
        }
        public static void Print()
        {
            while (keepPrinting)
            {
                propertyUpdated.WaitOne();
                Console.WriteLine("Number is " + Storage.Number);
            }
        }
    }
