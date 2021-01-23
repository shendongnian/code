    System.Timers.Timer t = new System.Timers.Timer(700);
    t.Elapsed += (object s1, System.Timers.ElapsedEventArgs e1) => {
                    Thread.Sleep(700);
                    t.stop();
                };  
    new System.Threading.Thread(() => {
    //my code here
    }).Start();
