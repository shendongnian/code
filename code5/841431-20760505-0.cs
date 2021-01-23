           private void Form1_Load(object sender, EventArgs e)
            {
                Thread t = new Thread(KeepRotating);   // Kick off a new thread
                t.Start();
            }
           void KeepRotating()
            {
                for (float i = 1; i <= 360; i++)
                {
                    RotateImage(pictureBox1, image, i);
                    Thread.Sleep(20);  // for slower rotation, Avoid if not needed
                    if (i == 360f)
                    {
                        i = 1f;
                    }
                }
            }
