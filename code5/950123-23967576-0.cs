    if (!string.IsNullOrEmpty(axWindowsMediaPlayer1.URL)){
    axWindowsMediaPlayer1.Ctlcontrols.pause();
    System.Drawing.Image ret = null;
    try
    {
        // take picture BEFORE saveFileDialog pops up!!
        Bitmap bitmap = new Bitmap(axWindowsMediaPlayer1.Width, axWindowsMediaPlayer1.Height);
        {
            Graphics g = Graphics.FromImage(bitmap);
            {
                Graphics gg = axWindowsMediaPlayer1.CreateGraphics();
                {
                    //timerTakePicFromVideo.Start();
                    this.BringToFront();
                    g.CopyFromScreen(
                        axWindowsMediaPlayer1.PointToScreen(
                            new System.Drawing.Point()).X,
                        axWindowsMediaPlayer1.PointToScreen(
                            new System.Drawing.Point()).Y,
                        0, 0,
                        new System.Drawing.Size(
                            axWindowsMediaPlayer1.Width,
                            axWindowsMediaPlayer1.Height)
                        );
                }
            }
            // afterwards save bitmap file if user wants to
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ret = System.Drawing.Image.FromStream(ms);
                    ret.Save(saveFileDialog1.FileName);
                }
            }
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
