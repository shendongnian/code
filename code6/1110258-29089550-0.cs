    Action isExcelInteractive = IsExcelInteractive;
    
    private async void btnOk_Click(object sender, EventArgs e)
    {
        IAsyncResult result = isExcelInteractive.BeginInvoke(ItIsDone, null);
        result.AsyncWaitHandle.WaitOne();
        Console.WriteLine("YAY");
    } 
    static void IsExcelInteractive(){
       while (something_is_false) // do your check here
       {
           if(something_is_true)
              return true;
       }
       Thread.Sleep(1);
    }
    void ItIsDone(IAsyncResult result)
    {
       this.isExcelInteractive.EndInvoke(result);
    }
                   
