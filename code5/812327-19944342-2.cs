    class Form1
    {
        private Process process;
        private void Form1_Load(object sender, EventArgs e)
		{
            //running notepad as an example
			process = Process.Start("notepad"); 
		}
        
        //and then at button handler kill that process
        private void button1_Click(object sender, EventArgs e)
        {
            //consider adding check for null
            process.Kill();
        }
    }
