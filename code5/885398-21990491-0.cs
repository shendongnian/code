    namespace CollectionTester {
        class Program {
            static void Main(string[] args) {
                MyQueue queue = new MyQueue();
                Sender thread = new Sender(queue);
                Receiver rec = new Receiver(queue);
    
                thread.Start();
                System.Threading.Thread.Sleep(2000);
                rec.Start();
    
                Console.ReadKey();
            }
        }
    
        public class MyQueue {
            private System.Collections.Concurrent.BlockingCollection<DateTime> col = null;
            private TimeSpan timeout = new TimeSpan(0, 0, 6);
    
            public MyQueue() {
                this.col = new System.Collections.Concurrent.BlockingCollection<DateTime>(5);
            }
    
            public System.Collections.Concurrent.BlockingCollection<DateTime> TheCollection {
                get { return col; }
            }
    
            public void setVal(DateTime ts) {
                Console.WriteLine("try to add " + ts.ToLongTimeString());
                while (!col.TryAdd(ts)) {
                    deleteOlder();
                }
                ShowContent(" ++ ");
            }
    
            public void ShowContent(string tag) {
                foreach (DateTime i in col) {
                    Console.WriteLine(tag + " " + i.ToLongTimeString());
                }
            }
    
            private bool deleteOlder() {
                DateTime old = DateTime.Now;
                bool ret = false;
    
                foreach (DateTime item in col) {
                    if (DateTime.Now.Subtract(item) >= timeout) {
                        col.TryTake(out old);
                        ret = true;
                        break;
                    }
                }
                if (ret == true) {
                    return deleteOlder();
                }
                else {
                    return ret;
                }
            }
        }
    
        public class Receiver {
            private MyQueue theCollection = null;
    
            public Receiver(MyQueue thecol) {
                this.theCollection = thecol;
            }
    
            public void Start() {
                Task.Factory.StartNew(() => {
                    foreach (DateTime value in theCollection.TheCollection.GetConsumingEnumerable()) {
                        Console.WriteLine(" >>> " + value.ToLongTimeString());
                        theCollection.ShowContent(" -- ");
                        System.Threading.Thread.Sleep(2000);
                    }
                    Console.WriteLine("Nothing in the queue");
                });
            }
        }
        public class Sender {
            private MyQueue theCollection = null;
    
            public Sender(MyQueue thecol) {
                this.theCollection = thecol;
            }
    
            public void Start() {
                Task.Factory.StartNew(() => {
                    for (int i = 1; i <= 10; i++) {
                        Console.WriteLine("Iteration: " + i.ToString());
    
                        DateTime ts = DateTime.Now;
                        theCollection.setVal(ts);
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.WriteLine("Nothing else to add...");
                    theCollection.TheCollection.CompleteAdding();
                });
            }
        }
    }
