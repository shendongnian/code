    var mre = new ManualResetEvent(false);
    Thread audio;
    bool play = true; // global keep running flag.
    // Call this ONCE, at the start of your app.
    void Init()
    {
        audio  = new Thread(PlayQueue);
        audio.Start();
    }
    void udpClient_DataReceived(byte[] bytes) 
    {
        audioQueue.Enqueue (bytes); //ConcurrentQueue
        
        mre.Set(); // this signals that we have data
        // disbale the timer if the stream is done
        // and/or set play to false
        // based on bytes received in your byte array
    }
    
    private void PlayQueue()
    {
        var aTimer = new System.Timers.Timer(1000); // play after 1 second
        var timeEvent = new ManualResetEvent(false);
        aTimer.Elapsed += (s,e) => { timeEvent.Set(); };  // the time will start the play
        byte[] a;
        mre.WaitOne();  // wait until there is data
        atimer.Enabled = true; // it will start playimg after 1000 miliseconds
        timeEvent.WaitOne(); // wait for the timer
        
        while (play) {
            if (audioQueue.TryDequeue (out a))  // check if we succesfull got an array
            {
               audIn.PlayAudio (a);
            }
        }
    }
