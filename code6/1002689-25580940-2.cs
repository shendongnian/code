    public class ProducerConsumer {
        public delegate void FileAddedDelegate(string file);
        public delegate void AllFilesProcessedDelegate();
        public event FileAddedDelegate FileAdded;
        public event AllFilesProcessedDelegate AllFilesProcessed
        readonly Queue<string> queue; int counter;
        public ProducerConsumer(int workerCount, IEnumerable<string> list) {
            queue = new Queue<string>(list); // fill the queue
            counter = queue.Count; // set up counter
            for (int i = 0; i < workerCount; i++)
                Task.Factory.StartNew(Consumer);
        }
        private void Consumer() {
            FileChecker fileChecker = new FileChecker();
            for(;;) {
                string file;
                lock(queue) { // synchronize on the queue
                    if (queue.Count == 0) return;  // we are done
                    file = queue.Dequeue(); // get file name to process
                } // release the lock to allow other consumers to access the queue
            //  do the job
                string result = fileChecker.Check(file);
                if (result != null && FileAdded != null)
                    FileAdded(result);
            //  decrement the counter
                if(Interlocked.Decremet(counter) != 0)
                    continue; // not the last
            //  all done - we were the last
                if(AllFilesProcessed != null)
                    AllFilesProcessed()
                return;
            }
        }
    }
