            // Extracting parameter from form
            string para1=textbox1.Text;
            
            // State the program to be start; PATH is the path to program .exe
            ProcessStartInfo startInfo = new ProcessStartInfo(PATH);
            // Passing arguments :para1 extracted from textbox (string type) 
            startInfo.Arguments = para1 
            // Starting process
            Process exec= Process.Start(startInfo);
            
            // optionally waiting for execution
            exec.WaitForExit();
