    private void btnGetMusic_Click(object sender, EventArgs e)
    {
        System.Threading.Thread MusThread = new System.Threading.Thread(getMus.GetMusic);
        MusThread.IsBackground = true;
        MusThread.Start();
        //this waits timeout # of milliseconds for the thread to be done
        //if thread not done, update the label
        //if thread done, exits while loop
        while (!MusThread.Join(timeout))
        {
            lblNumberOfSongs.Text = getMus.holder.Count.ToString();
        }
    }
    
