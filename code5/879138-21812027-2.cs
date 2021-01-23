    var mre = new ManualResetEvent(false);
    Thread audio;
    bool play = true; // global keep running flag..
    aTimer = new System.Timers.Timer(1000); // play after 1 second
    // Call this ONCE, at the start of your app.
    void Init()
    {
        audio  = new Thread(PlayQueue);
        audio.Start();
        aTimer.Elapsed = () => { mre.Set(); } ;  // the time will start the play
    }
    void udpClient_DataReceived(byte[] bytes) 
    {
        audioQueue.Enqueue (bytes); //ConcurrentQueue
        
        if (!atimer.Enabled) 
        {   
             atimer.Enabled = true; // it will start playimg after 1000 miliseconds
        }
    
        // disbale the timer if the stream is done
        // and/or set play to false
        // based on bytes received in your byte array
   }
    
    private void PlayQueue()
    {
        byte[] a;
        mre.WaitOne();  // wait until the threshold of 10 is reached
        while (play) {
            if (audioQueue.TryDequeue (out a))  // check if we succesfull got an array
            {
               audIn.PlayAudio (a);
            }
        }
    }
