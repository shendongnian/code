        public void Button1_Click(object sender,EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;    // every 3 seconds
           
            int track = 0; // where are we, aka the index
            txtOutput.Text = String.Empty;
            var output = new StringBuilder(); // use a stringbuilder 
            timer.Tick += (timerObject, timerArgs) =>
            {
                 // check if track exists 
                 // I couldn't find the type of pQueueOrdered so
                 // I hope this works
                 // otherwise track<=nodeNum might be an alternative
                 if (pQueueOrdered.ContainsKey(track))
                 {
                     output.AppendFormat(String.Format(
                         "\r\n\nThe node number  :{0}   Has the Prority:  {1}",  
                         pQueueOrdered.ContainsKey(track),
                         pQueueOrdered[track]));
                     txtOutput.Text = output.ToString();
                     // increase track to get the next
                     // item at the next Tick
                     track++;
                 }
                 // stop if done... 
                 if (track > nodenum+1)
                 {
                     timer.Stop();
                     output.AppendFormat(String.Format(
                        "\r\r\n  Ends x {0}",
                        track));
                     txtOutput.Text =  output.ToString();
                 }
             }
             
             timer.Start();
        }
