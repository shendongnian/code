    private string fileName = "";
            private void button1_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    pictureBox1.ImageLocation = fileName; 
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
              
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.WindowStyle = ProcessWindowStyle.Hidden;
    
                    info.FileName = "console.exe";
                    info.Arguments = fileName;
                    Process p = new Process();
    
                    p.StartInfo = info;
                    p.Start();
                    p.WaitForExit();
    
                }
