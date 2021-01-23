    if (pname.Length != 0 && this.processId == 0)
    {
      for (int i = 0; i < pname.Length; i++)
      { 
        pname[i].Kill();
        pname[i].WaitForExit();
      }
      //Again find the TestApp
      pname = Process.GetProcessesByName("TestApp");                        
    }
