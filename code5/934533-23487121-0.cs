       "Async" in a very eaaaaaaaaaaaaasy way, by using my way: Async.cs
        
        Usage>
        
        /* ___________________ Summary ___________________ */
        Async.GetDataAsync<List<double>>(GetSomeDoubles, DoubleArrived);// DoubleArrived takes List<double> as param
        
        Async.DoAsync(doSomethingIns, doNextthingIns); // both are voids
        
        
        /* ___________________ Details ___________________ */
        
        /* ========= GetAsync ========= */
        Async.GetDataAsync<List<int>>(
        () =>
        {
          //Code as you like
          System.Threading.Thread.Sleep(2000);
          return Enumerable.Range(0, 10).ToList();
        },
        (List<int> data) =>
        {
          MessageBox.Show(data.Count.ToString());
        });
        
        /* ========= GetAsync ========= */ 
        Async.GetDataAsync<object>(
        () =>
        {
          //Code as you like
          System.Threading.Thread.Sleep(2000);
          return 5;
        },
        delegate (object data)
        {
          MessageBox.Show(data.ToString());
        });
        
        /* ======== Do some thing Async ======== */
        Async.DoAsync(
        () =>
        {
          //Code as you like
          System.Threading.Thread.Sleep(3000);
        },
        () =>
        {
          MessageBox.Show("You did it async :)");
        });
        
        /* ======== Do some thing Async ======== */
        Async.DoAsync(
        () =>
        {
          //Code as you like
          System.Threading.Thread.Sleep(3000);
        },
        delegate()
        {
          MessageBox.Show("You did it async again :)");
        });
