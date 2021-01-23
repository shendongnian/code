    class Form1
    {
        private Process process;
        private void Form1_Load(object sender, EventArgs e)
		{
			ProcessStartInfo exe = new ProcessStartInfo();
			exe.Arguments = "arguments";
			exe.FileName = "file.exe";
			process = Process.Start(exe);
		}
        
        //and then at button handler kill that process
        private void button1_Click(object sender, EventArgs e)
        {
            process.Kill();
        }
    }
