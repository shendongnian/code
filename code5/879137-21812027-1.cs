    var mre = new ManualResetEvent(false);
    Thread audio;
    bool play = true; // global keep running flag..
    // Call this ONCE, at the start of your app.
    void Init()
    {
        audio  = new Thread(PlayQueue);
        audio.Start();
    }
    void udpClient_DataReceived(byte[] bytes) 
    {
        audioQueue.Enqueue (bytes); //ConcurrentQueue
    
        if (audioQueue.Count > 10) { //count > 10 is about a one second delay
            mre.Set(); // signal  playing
        }
        // you could call mre.Reset if you feel playing should pause
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
