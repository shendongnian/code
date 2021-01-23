    public void waveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
    {
        string fileName;
        foreach (ListViewItem lvi in playListView.Items)
        {
            fileName = lvi.SubItems[1].Text;
            if(lvi.Checked == true)
            {
                int finIndex;
                lvi.Checked = false;
                finIndex = lvi.Index;
                finIndex++;
                if(finIndex < playListView.Count())
                {
                    var nextGuy = playListView.Items[finIndex];
                    nextGuy.Checked = true;
                    //Play the file and what not. 
                }
                    
            }
        }
    }
    
