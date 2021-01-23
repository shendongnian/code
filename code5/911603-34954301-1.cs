    System.Timers.Timer t = new System.Timers.Timer(700);
    t.Start()
    t.Elapsed += (object s1, System.Timers.ElapsedEventArgs e1) => {
                    new System.Threading.Thread(() => {
                    //my code here
                    }).Start();
                };  
    
