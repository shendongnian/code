    var script = new Queue<Action>();
    script.Enqueue( movedown);
    script.Enqueue( moveup);
    var timer = new Timer(1000);
    timer.Elapsed += (s,e)=> 
      {
        if (script.Count > 0)
        {
           script.Dequeue()();
        }
        else 
        {
           timer.Enabled = false; 
        } 
      };
    timer.Enabled = true;
