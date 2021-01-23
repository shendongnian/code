    System.Diagnostics.Process notepad = new Process();
    notepad.StartInfo.FileName = "notepad.exe";
    notepad.Start();
    System.Threading.Thread.Sleep(500);
    // get the text from the users input
    string msg = textBox1.Text;
    // Send the string to the application that has focus 
    SendKeys.Send(msg);
