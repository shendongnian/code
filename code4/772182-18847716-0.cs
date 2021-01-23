              var cts = new CancellationTokenSource();
              Task
                .Factory
                .StartNew(() => 
                 { 
                     /* HeavyFunction */ 
                     while (someCondition)
                     {
                        cts.Token.ThrowIfCancellationRequested();
                        /*  do something */
                     }
                 }, cts.Token);
