    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!backgroundWorker1.CancellationPending)
        {
            if (tempCpuValue >= (float?)nud1.Value || tempGpuValue >= (float?)nud1.Value)
            {
                soundPlay = true;
                NudgeMe();
            }
            else
            {
                soundPlay = false;
                stop_alarm = true;
            }
            tempCpuValue = Core.cpuView(pauseContinueDoWork, cpu, this, data, tempCpuValue, button1);
            tempGpuValue = Core.gpuView(pauseContinueDoWork, data, tempGpuValue, button1);
            this.BeginInvoke(new Action(() => data = new List<string>()));
            tempCpuValue = Core.cpuView(pauseContinueDoWork, cpu, this, data, tempCpuValue, button1);
            tempGpuValue = Core.gpuView(pauseContinueDoWork, data, tempGpuValue, button1);
            this.BeginInvoke(new Action(() => listBox1.DataSource = null));
            this.BeginInvoke(new Action(() => listBox1.DataSource = data));
        }
        completed = true;
        autoreset.Set();
    }
    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Are you Sure you want to Exit. Click Yes to Confirm and No to continue", "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
        else
        {
            if (!completed)
            {
                this.backgroundWorker1.CancelAsync();
                Hide(); // hide the form while waiting for the bw to terminate
                autoreset.WaitOne();
            }
        }
    }
