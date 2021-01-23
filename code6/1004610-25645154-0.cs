    // Define the blocking collection with a maximum size of 15.
    const int maxSize = 15;
    var data = new BlockingCollection<int>(maxSize);
    
    // Populate data.
    // Do this in a separate task since BlockingCollection<T>.Add()
    // blocks when the specified capacity is reached.
    var addingTask = new Task(() => {
    	for (int i = 1; i <= 20; i++) {
    		data.Add(i);
    	}
    ).Start();
    
    // Define a signal-to-stop bool
    var stop = false;
    
    // Create 15 handle tasks.
    // You can change this to threads if necessary, but the general idea is that
    // each consumer continues to consume until the stop-boolean is set.
    // The Take method only returns an item if one is available.
    for (int t = 0; t < maxSize; t++) {
    	var handlingTask = new Task(() => {
    		while (!stop) {
    			int item = data.Take();
    			// Note: the Take method will block until an item comes available.
    			HandleThisItem(item);
    		}
    	});
    	handlingTask.Start();
    };
    
    // Wait until you need to stop. When you do, set stop true
    stop = true;
