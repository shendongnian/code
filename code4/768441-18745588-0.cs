        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var tasks = new List<Task>();
            Console.WriteLine("Main Thread" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            tasks.Add(new Task(() => Console.WriteLine("Task 1:" + System.Threading.Thread.CurrentThread.ManagedThreadId)));
            tasks.Add(new Task(() => Console.WriteLine("Task 1:" + System.Threading.Thread.CurrentThread.ManagedThreadId)));
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.ContinueWhenAll(tasks.ToArray(), LoadComplete, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, context);
            tasks.ForEach(task => task.Start());
            
            Console.ReadLine();
        }
        private void LoadComplete(Task[] tasks)
        {
            Console.WriteLine("Completion Task" + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
