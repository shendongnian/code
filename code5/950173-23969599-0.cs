    public class Form1:Form
    {
        Timer timer = new System.Windows.Forms.Timer();
        int track = 0; // where are we, aka the index
    
        // make sure Form1 is hooked up to the load event
        public void Form1_Load(object sender, EventArgs e)
        {
             timer.Interval = 3000;    // every 3 seconds
             timer.Enabled= false;     // not enabled yet
             timer.Tick += (timerObject, timerArgs) =>
             {
                 // check if track exists 
                 // I couldn't find the type of pQueueOrdered so
                 // I hope this works
                 // otherwise track<=nodeNum might be an alternative
                 if (pQueueOrdered.ContainsKey(track))
                 {
                     txtOutput.Text += String.Format(
                         "\r\n\nThe node number  :{0}   Has the Prority:  {1}",  
                         pQueueOrdered.ContainsKey(track),
                         pQueueOrdered[track]);
                     // increase track to get the next
                     // item at the next Tick
                     track++;
                 }
                 // stop if done... 
                 if (track > nodenum+1)
                 {
                     timer.Stop();
                     this.txtOutput.Text += String.Format(
                        "\r\r\n  Ends x {0}",
                        track.ToString());
                 }
             }
        }
    
        public void Button1_Click(object sender,EventArgs e)
        {
            track = 0; // set our index to the initial value
            txtOutput.Text = String.Empty;
            timer.Start();
        }
    }
