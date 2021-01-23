    class Form1
    {
        private Process process;
        private void Form1_Load(object sender, EventArgs e)
		{
			process = Process.Start("notepad"); //running notepad as an example
		}
        
        //and then at button handler kill that process
        private void button1_Click(object sender, EventArgs e)
        {
            //consider adding check for null
            process.Kill();
        }
    }
