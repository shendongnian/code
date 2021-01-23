        public partial class Form1 : Form
        {
            private const int UrlCount = 1000;
            private const int taskCount = 10;
            private ConcurrentQueue<string> urlList;
            private List<Task> taskList;
            public Form1()
            {
                InitializeComponent();
            }
            private void ResetQueue()
            {
                // fake up a number of strings to process
                urlList = new ConcurrentQueue<string>(Enumerable.Range(0, UrlCount)
                          .Select(i => "http://www." + Guid.NewGuid().ToString() + ".com"));
            }
            private void button1_Click(object sender, EventArgs e)
            {
                ResetQueue();
                var taskFactory = new TaskFactory();
                // start a bunch of tasks
                taskList = Enumerable.Range(0, taskCount).Select(i => taskFactory.StartNew(() => ProcessUrl()))
                                      .ToList();
            }
            void ProcessUrl()
            {
                string current;
                // keep grabbing items till the queue is empty
                while (urlList.TryDequeue(out current))
                {
                    // run your code
                    FindWIN(current);
                    // invoke here to avoid cross thread issues
                    Invoke((Action)(() => UpdateProgress()));
                }
            }
            void FindWIN(string url)
            {
                // your code here
                // as a demo, sleep a sort-of-random time between 0 and 100 ms
                Thread.Sleep(Math.Abs(url.GetHashCode()) % 100);
            }
            void UpdateProgress()
            {
                // work out what percentage of the queue is processed
                progressBar1.Value = (int)(100 - ((double)urlList.Count * 100.0 / UrlCount));
            }
        }
