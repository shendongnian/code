    System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("ProcessName");//Add visuals procname here
                if (proc.Length > 0)
                {
                    MessageBox.Show("Process running");
                    if (timer1.Enabled == false)
                    {
                        timer1.Start();//Starts the countdown}
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show("Process not running");
                        if (timer1.Enabled == true)
                        {
                            timer1.Stop();//Stops the countdown}
                            System.Threading.Thread.Sleep(1000);
                        }
