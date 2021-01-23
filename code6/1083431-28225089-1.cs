        private System.Threading.ManualResetEvent MRE = new System.Threading.ManualResetEvent(false);
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            bool result = false;
            for (int i = 1; i <= 5; i++ )
            { 
                Console.WriteLine("Message " + i.ToString() + " Sent");
                
                MRE.Reset();
                await Task.Run(delegate()
                {
                    result = MRE.WaitOne(TimeSpan.FromSeconds(10)); // wait up to ten seconds for MRE to be set
                });
                if (result)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Timeout Fail");
                }
            }
            button1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // simulated receipt of something
            Console.WriteLine("...bloop...");
            MRE.Set(); // tell the main loop it's okay to continue
        }
