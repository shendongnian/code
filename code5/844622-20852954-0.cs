    you have to do run shell commands from C#
    
    string strCmdText; 
    strCmdText= "/C copy /b Image1.jpg + xyz.rar Image2.jpg"; System.Diagnostics.Process.Start("CMD.exe",strCmdText);
    
    **EDIT:**
    
    This is to hide the cmd window.
    
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = "/C copy /b Image1.jpg + xyz.rar Image2.jpg";
    process.StartInfo = startInfo;
    process.Start();
