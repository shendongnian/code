    private ConcurrentQueue<String> __OutputBuffer = new ConcurrentQueue<String>();
    
    private void ProcessOutput()
    {
        string _Item;
        if (__OutputBuffer.TryDequeue(out _Item))
        {
             try
             {
                  Browser.DocumentText += "<span style='font-family: Tahoma; font-size: 9pt;'>" + _Item + "</span>";
                 //Exception On Line Above!
             }
             catch (Exception) { }
        }
    }
