        //This will append each new line to your textBox1 (multiline)
        private void AppendLine(string line)
        {
            if (textBox1.InvokeRequired){
                if(textBox1.IsHandleCreated) textBox1.Invoke(new Action<string>(AppendLine), line);
            }
            else if(!textBox1.IsDisposed) textBox1.AppendText(line + "\r\n");
        }
        //place this code in your form constructor
        Shown += (s, e) => {
          new Thread((() =>
          {          
            while (true){
               string line = CMDProcess.StandardOutput.ReadLine();
               AppendLine(line);    
               //System.Threading.Thread.Sleep(100); <--- try this to see it in action   
           }
         })).Start();
       };
       //Now every time your CMD outputs something, the lines will be printed (in your textBox1) like as you see in the CMD console window.       
