    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        List<Foo> results = new List<Foo>();
    
        // any loop here - foreach, while
        for(int i = 0; i < steps_count; i++)
        {    
             // check status on each step
             if (bw.CancellationPending == true) 
             {
                 e.Cancel = true;
                 return; // abort work, if it's cancelled
             }
    
             results.Add(abd()); // add part of results
        }
    
        e.Result = results; // return all results
    }
