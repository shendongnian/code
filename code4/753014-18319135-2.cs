    public byte[] SetSpeed;
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        if (trackBar1.Value == 0)
        {
            try
            {
                stop = true;
                UpdateSThread.Abort();
                Thread.Sleep(350);
            }
            catch { }
            SetSpeed = new byte[]{0x00,0x00,0x00,0x00};
            WriteMem(GetPlayer() + STATUS_OFFSET, SetSpeed);
            label1.Text = "Normal";              
        }
    }
