    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        List<Foo> results = new List<Foo>();
    
        for(int i = 0; i < steps_count; i++)
        {    
             if (bw.CancellationPending == true) 
             {
                 e.Cancel = true;
                 return;
             }
    
             results.Add(abd()); // add part of results
        }
    
        e.Result = results;
    }
