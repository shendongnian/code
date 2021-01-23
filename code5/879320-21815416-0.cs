        PermeabilityTest Run_Test = new PermeabilityTest();
        public Thread WorkerThread;
        public form1()
        {
            // Register on the Progress event
            Run_Test.Progress += Run_Test_Progress;
        }
        void Run_Test_Progress(string message)
        {
 	    if(listBox.InvokeRequired)
            {
                // Running on a different thread than the one created the control
                Delegate d = new ProgressEventHandler(Run_Test_Progress);
                listBox.Invoke(d, message);
            }
            else
            {
                // Running on the same thread which created the control
                listBox.Items.Add(message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //enable timer for test duration display
            timer1.Enabled = true;
            //create and start new thread.
            WorkerThread = new Thread(Run_Test.RunTest);
            WorkerThread.Start();
        }
