    public class Class1Singleton
    {
        // This is the way Jon Skeet recommends implementing a singleton in C#
        // See http://csharpindepth.com/Articles/General/Singleton.aspx
        static readonly Class1Singleton instance = new Class1Singleton();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Class1Singleton() { }
        // There's only one instance of Class1Singleton so there's
        // no advantage in making the members static
        private List<Class1> Class1s;
        private Timer saveClass1Timer;
        private readonly object lock1 = new object();
        Class1Singleton()
        {
        }
        public static Class1Singleton Instance
        {
            get { return instance; }
        }
        public void StartTimer()
        {
            // If you're using this class in a multi-thread environment,
            // all methods that access the list or timer should be locked
            lock (lock1)
            {
                if (saveClass1Timer == null)
                {
                    saveClass1Timer = new Timer(10000);
                    //saveClass1Timer.Interval = 10000;
                    saveClass1Timer.Elapsed += new ElapsedEventHandler(SaveClass1);
                    saveClass1Timer.Enabled = true;
                }
            }
        }
        // SaveClass1 doesn't need to be public
        private void SaveClass1(object sender, ElapsedEventArgs e)
        {
            lock (lock1)
            {
                SaveWorkoutList();
                ClearWorkoutList();
            }            
        }
        private void SaveWorkoutList()
        {
            //new Class1Repository().InsertAllClass1(Class1s);
        }
        public void InsertClass1(List<Class1> Class1)
        {
            lock (lock1)
            {
                if (Class1s == null)
                    Class1s = new List<Class1>(Class1);
                else
                    Class1s.AddRange(Class1);
            }
        }
        private void ClearWorkoutList()
        {
            if (Class1s != null)
            {
                Class1s.Clear();
            }
        }
        public void StopTimer()
        {
            lock (lock1)
            {
                if (Class1s != null && Class1s.Count > 0)
                {
                    SaveWorkoutList();
                    ClearWorkoutList();
                }
                if (saveClass1Timer != null && saveClass1Timer.Enabled == true)
                {
                    saveClass1Timer.Stop();
                }
            }
        }
    }
