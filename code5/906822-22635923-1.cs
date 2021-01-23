     class Program
        {
            static DateTime _lastInvokation;
            static int somedelInterval = 10000;
    
            public void someFun1(Object obj)
            {
                Console.WriteLine("Start1 " + DateTime.Now);
                _lastInvokation = DateTime.Now;
            }
    
            public void changeTime1(Object obj)
            {
                int dueTime = somedelInterval - (int)(DateTime.Now - _lastInvokation).TotalMilliseconds;
                somedelInterval = 2000;
                if (dueTime > 0)
                    someTime1.Change(dueTime, somedelInterval);
            }
    
            public static TimerCallback somedel1;
            public static Timer someTime1;
    
            public static TimerCallback changeTimedel1;
            public static Timer changerTimer1;
    
            static void Main(string[] args)
            {
                Program pr = new Program();
    
                somedel1 = new TimerCallback(pr.someFun1);
                someTime1 = new Timer(somedel1, null, Timeout.Infinite, somedelInterval);
                _lastInvokation = DateTime.Now;
    
                changeTimedel1 = new TimerCallback(pr.changeTime1);
                changerTimer1 = new Timer(changeTimedel1, null, 0, 10);
    
    
                Console.ReadLine();
            }
        }
