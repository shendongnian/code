    var rr_list = new Dictionary<int, Queue<process>>();
    
    process proc = new process{
         Proc_a = 1,
         Proc_b = 2,
         Proc_Index = 4 };
    
    rr_list[proc.Proc_Index].Enqueue(proc); 
