      static void Main(string[] args)
      {
          String answ;
          while (true)
          {
               answ = GetActiveWindowTitle();
               if (answ == null)
               {
                   Console.WriteLine("NO active program");
               }
               else {
                  Console.WriteLine(answ);
               }
            Thread.Sleep(1000);
           }
     }
    
     [DllImport("user32.dll")]
     static extern IntPtr GetForegroundWindow();
    
     [DllImport("user32.dll")]
     static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    
     static private string GetActiveWindowTitle()
     {
        const int nChars = 256;
        StringBuilder Buff = new StringBuilder(nChars);
        IntPtr handle = GetForegroundWindow();
    
        if (GetWindowText(handle, Buff, nChars) > 0)
        {
            return Buff.ToString();
         }
         return null;
      }
