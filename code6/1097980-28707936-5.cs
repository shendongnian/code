    private void ProgressBar_Tick(object sender, EventArgs e)
    {
        if (filesize <= sixtyfree.Maximum - sixtyfree.Value)
        {
            sixtyfree.Value += filesize;
        }
        else
        {
            sixtyfree.Value = sixtyfree.Maximum;
        }
        ProgressBar.Stop();
    }
