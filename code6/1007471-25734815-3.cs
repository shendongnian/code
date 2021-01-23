    IntPtr notepadHwnd = FindWindow("Notepad",(string)null);
    if (notepadHwnd == null)
    {
      System.Diagnostics.Process notepad = new Process();
      notepad.StartInfo.FileName = "notepad.exe";
      notepad.Start();
      System.Threading.Thread.Sleep(500);
      notepadHwnd = FindWindow("Notepad",(string)null);
    }
    // get the text from the users input
    string msg = textBox1.Text;
    if (notepadHwnd != null)
    {    
       SetForgroundWindow(notepadHwnd);
       // Send the string to the application that has focus 
       // note: If you need to erase existing text (ie. on TextChanged) 
       // you could use SendKeys.Send("^a{BACKSPACE}"); to select all and delete
       SendKeys.Send(msg);
    }
