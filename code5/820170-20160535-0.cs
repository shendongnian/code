        Timer t = new Timer();
        Point currPos;
        Point oldPos;
        private void Form1_Load(object sender, EventArgs e)
        {
            currPos = Cursor.Position;
            t.Interval = (4000);
            t.Enabled = true;
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                currPos = Cursor.Position;
                if (oldPos == currPos)
                {
                    t.Stop();
                    // I'm not clear what you want here - perhaps remove the messagebox and lock the workstation?
                    var res = MessageBox.Show("Are you present", "Alert");
                    if (res == DialogResult.OK)
                    {
                        t.Start();
                    }
                    // Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                }
                oldPos = currPos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
