    public interface IMyExternalTask
    {
        void DoSomething();
    }
    // ...
    List<IMyExternalTask> myTasks = new List<IMyExternalTask>();
    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    t.Interval = 1000; // Call it every second
    t.Tick += delegate(object sender, EventArgs e) { 
        foreach (var myTask in myTasks)
            myTask.DoSomething();
    };
    t.Start();
