    try
            { 
            for (int index = 0; index < fileNum / 2 - 1; index++)
            {
                aTimer = new System.Timers.Timer(10000);
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = Convert.ToInt64(arrTime[index]);
                aTimer.Enabled = true;
                pictureBox1.Image = list[index];
                pictureBox2.Image = list[index+1];
            }
            }
            catch
            {
                MessageBox.Show(e.ToString());
            } 
