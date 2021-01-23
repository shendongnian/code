    class Class2 {
    	private Queue<Output_args> outputs = new Queue<Output_args>();
    	
    	public void newOutput(object sender, Output_args args) {
    		lock (outputs) {
    			outputs.Enqueue(args.Copy());
    		}
    	}
    	
    	public void processor(){
    		lock (outputs) {
    			if (outputs.Count > 0) {
    				var lastoutput = outputs.Dequeue();
    				
    				if (lastoutput.entrytime + 10000000 > System.DateTime.Now.Ticks) {
    				// do something
    				}
    			}
    		}
    	}
    }
