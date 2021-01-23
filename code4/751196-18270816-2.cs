     private void button1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string openexe= @"C:\Users\marek\Documents\Visual Studio 2012\Projects\tours\tours\bin\Debug\netpokl.exe";
            p.StartInfo.FileName = openexe;
            p.EnableRaisingEvents = true;
            p.Exited +=new EventHandler(p_Exited);
            p.Start();            
        }
     private void p_Exited(object sender, EventArgs e)
        {
            //Do stuff here
            MessageBox.Show("Exited");
        }
