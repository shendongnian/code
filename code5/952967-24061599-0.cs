    public class MyState{
       public string Example {get;set;}
    }
    private MyState _state;
    private void MethodCalledFromUIThread()
    {
        //Update UI.
        TextBox1.Text = string.Empty;
        //Start parallel work in a new thread.
        new TaskFactory().StartNew(() => ThreadedMethod())
            //Wait for background threads to complete
            .Wait();
         //Update UI with result of processing.
         TextBox1.Text = _state.Example;
    }
    private void ThreadedMethod()
    {
         //load dsResult
         Parallel.ForEach(dsResult.Tables[0].Rows, dr =>
         {
             //process data in parallel.
         }
         //Update the State object so the UI thread can get access to the data
         _state = new MyState{Example = "Data Updated!";}
    }
