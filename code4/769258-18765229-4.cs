    public partial class MainWindow : Window
    {
        List<MyThread> threads = new List<MyThread>();
    
        public MainWindow()
        {
            var thread1 = new MyThread();
            thread1.A = () => TestParallel1();
            thread1.RaisError += RaisError;
    
            var thread2 = new MyThread();
            thread2.A = () => TestParallel1();
    
    
            threads.Add(thread1);
            threads.Add(thread2);
    
            Parallel.ForEach(threads, t => { t.Start(); });
        }
    
        public void RaisError()
        {
            Parallel.ForEach(threads, t => { t.Stop(); });
        }
    
        public static void TestParallel1()
        {
            throw new MyException();
        }
    }
    
    public class MyException:Exception{}
    
    public class MyThread
    {
        public Action A { get; set; }
        public delegate void Raiser();
        public event Raiser RaisError;
    
        public void Start()
        {
            try
            {
                A.Invoke();
            }
            catch (MyException me)
            {
                RaisError();
            }
        }
    
        public void Stop()
        {
            // do some stop
        }
    }
