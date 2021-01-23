    using System.IO;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace BlockingCollection2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            public static void BC_GetConsumingEnumerableCollection()
            {
                List<string> fileNames = new List<string>();  // add filesNames
                string producerLine;
                System.IO.StreamReader file;
                List<BCtaskBC> bcs = new List<BCtaskBC>();  // add for each consumer
                // Kick off a producer task
                Task.Factory.StartNew(() =>
                {
                    foreach(string fileName in fileNames)
                    {
                        file = new System.IO.StreamReader(fileName);
                        while ((producerLine = file.ReadLine()) != null)
                        {
                            foreach (BCtaskBC bc in bcs)
                            {
                                bc.BC.Add(producerLine);  // if  any queue size gets to 1000000 then this blocks
                            }
                        }
                        file.Close();
                    }                 
                    // Need to do this to keep foreach below from hanging
                    foreach (BCtaskBC bc in bcs)
                    {
                        bc.BC.CompleteAdding();
                    }
                });
    
                // Now consume the blocking collection with foreach. 
                // Use bc.GetConsumingEnumerable() instead of just bc because the 
                // former will block waiting for completion and the latter will 
                // simply take a snapshot of the current state of the underlying collection. 
                //  Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
                Parallel.ForEach(bcs, bc =>
                {
                    foreach (string consumerLine in bc.BC.GetConsumingEnumerable())
                    {
                        bc.BCtask.ProcessTask(consumerLine);  
                    }
                } //close lambda expression
                     ); //close method invocation 
                // I think this need to be parallel
                //foreach (BCtaskBC bc in bcs)
                //{
                //    foreach (string consumerLine in bc.BC.GetConsumingEnumerable())
                //    {
                //        bc.BCtask.ProcessTask(consumerLine);
                //    }
                //}
            }
            public abstract class BCtaskBC
            {   // may need to do something to make this thread safe   
                private BlockingCollection<string> bc = new BlockingCollection<string>(1000000);  // this trotttles the size
                public BCtask BCtask { get; set; }
                public BlockingCollection<string> BC { get { return bc; } }
            }
            public abstract class BCtask
            {   // may need to do something to make this thread safe 
                public void ProcessTask(string S) {}
            }
        }
    }
  
 
