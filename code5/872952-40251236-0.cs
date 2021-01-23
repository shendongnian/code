    public class MyEventSignal
    {
        public MyEventSignal()
        {
        }
        public MyEventSignal(object _Sender, EventArgs _Args)
        {
            Sender = _Sender;
            Args = _Args;
        }
        object Sender { get; set; }
        EventArgs Args { get; set; }
    }
    private static object syncRoot = new object();
    private static Queue<MyEventSignal> eventSignalQueue = new Queue<MyEventSignal>();
    public static void EnqueueEvent(MyEventSignal NewEventSignal)
    {
        lock (syncRoot)
        {
            eventSignalQueue.Enqueue(NewEventSignal);
        }
    }
    private static MyEventSignal DequeueEvent()
    {
        MyEventSignal result;
        result = null;
        lock (syncRoot)
        {
            if (eventSignalQueue.Count > 0)
            {
                result = eventSignalQueue.Dequeue();
            }
        }
        return result;
    }
    private void TimerUI_Tick(object sender, EventArgs e)
    {
        MyEventSignal newSignal;
        newSignal = DequeueEvent();
        while (newSignal != null)
        {
            // start new thread to do stuff based on event signal
            newSignal = DequeueEvent();
        }
    }
    private void DoStuffOnParalleThread()
    {
        System.Threading.ThreadStart MyThreadStart;
        System.Threading.Thread MyThread;
        MyThreadStart = new System.Threading.ThreadStart(WorkerThreadRoutine);
        MyThread = new System.Threading.Thread(MyThreadStart);
        MyThread.Start()
    }
    private void WorkerThreadRoutine()
    {
        // Do stuff
        //Instead of raising an event do this of course specify your event args
        // or change the MyEventSignal class to suit
        Form1.EnqueueEvent(new WinApp.Form1.MyEventSignal(this, EventArgs.Empty));
    }
