    internal class AudioRecorder
    {  
        private ManualResetEvent mre = new ManualResetEvent(false);
     
        public void Start()
        {
            t.Start();
            while (!mre.WaitOne(200))
            {   
                // NAudio requires the windows message pump to be operational
                // this works but you better raise an event
                Application.DoEvents(); 
            }
        }
    
        private void Stop(object sender, ElapsedEventArgs args)
        {
            // better: raise an event from here!
            waveSource.StopRecording();
        }
        private void waveSource_RecordingStopped(object sender, EventArgs e)
        {
           /// ... your code here
           mre.Set();  // signal thread we're done!
        }
