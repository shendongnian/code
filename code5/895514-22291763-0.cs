    new TaskFactory()
    .StartNew(() =>
        {
            return 1;
        })
    .ContinueWith(x =>
        {
            //Prints out System.Threading.Tasks.Task`1[System.Int32]
            Console.WriteLine(x);
            //Prints out 1
            Console.WriteLine(x.Result);
        });
