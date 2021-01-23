    private void mainWinForm_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e) {
      if (e.KeyCode == Keys.Space) {
        objCtrl.Enabled = false;
        var timer = new System.Timers.Timer(1000);
        int count = 0;
        timer.SynchronizingObject = this;
        timer.AutoReset = true;
        timer.Elapsed += delegate {
          count++;
          if (count == 1) {
            label1.Text = File.ReadAllText("Countdown_3.txt");
          }
          if (count == 3) {
            label1.Text = File.ReadAllText("Countdown_2.txt");
          }
          if (count == 5) {
            label1.Text = File.ReadAllText("Countdown_1.txt");
          }
          if (count == 7) {
            webcam.Stop();
            label1.Text = File.ReadAllText("ImageCapturedPlusFrozen.txt");
          }
          if (count == 9) {
            label1.Text = File.ReadAllText("IdleForPreview.txt");
            label1.Refresh();
            Directory.CreateDirectory(DateTime.Now.ToString("yyyy-MM-dd"));
            using (Bitmap bmp = new Bitmap(imgVideo.ClientSize.Width, imgVideo.ClientSize.Height)) {
              using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawImage(imgVideo.Image,
                  new Rectangle(0, 0, bmp.Width, bmp.Height),
                  new Rectangle(0, 0, imgVideo.Image.Width, imgVideo.Image.Height),
                  GraphicsUnit.Pixel);
              }
              bmp.Save(DateTime.Now.ToString("yyyy-MM-dd") + "/ " + DateTime.Now.ToString("HH-mm-ss") + ".png", ImageFormat.Png);
            }
          }
          if (count == 20) {
            label1.Text = "Press Button to Start!";
            webcam.Start();
            timer.Stop();
            objCtrl.Enabled = true;
          }
        };
        timer.Start();
      }
    }
