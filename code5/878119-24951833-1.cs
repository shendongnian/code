    public static void produce() {
    
    	DataObject o2 = new DataObject();
    	Thread t = new Thread(consume);
    	t.Start(o2);
    
    	for (int i = 0; i < 10; i++) {
    		if (o2.queue.Count > 2) {
    			lock(o2.sb)
    				o2.sb.AppendLine("3 items read, waiting for consume to finish");
    
    			o2.wait.Set();
    			o2.parentWait.WaitOne();
    			o2.parentWait.Reset();
    		}
    
    		Thread.Sleep(500); // simulate reading data
    
    		lock(o2.sb)
    			o2.sb.AppendLine("Read file: " + i);
    
    		lock(o2.queue) {
    			o2.queue.Add(i);
    		}
    		o2.wait.Set();
    	}
    
    	o2.finished = true;
    	o2.wait.Set();
    }
    
    public class DataObject {
    	public bool finished = false;
    	public List<int> queue = new List<int>();
    	public ManualResetEvent wait = new ManualResetEvent(false);
    	public ManualResetEvent parentWait = new ManualResetEvent(false);
    	public StringBuilder sb = new StringBuilder();
    }
    
    public static void consume(Object o) {
    	DataObject o2 = (DataObject) o;
    
    	while (true) {
    		if (o2.finished && o2.queue.Count == 0)
    			break;
    
    		if (o2.queue.Count == 0) {
    			lock(o2.sb)
    				o2.sb.AppendLine("Nothing in queue, waiting for produce.");
    			o2.wait.WaitOne();
    			o2.wait.Reset();
    		}
    
    		Object val = null;
    		lock(o2.queue) {
    			val = o2.queue[0];
    			o2.queue.RemoveAt(0);
    		}
    
    		o2.parentWait.Set(); // notify parent to produce more
    
    		lock(o2.sb)
    			o2.sb.AppendLine("Loading data to SQL: " + val);
    
    		Thread.Sleep(500);
    	}
    }
