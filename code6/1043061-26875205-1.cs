    void Main()
    {
        var random = new Random();
        // stream of task parameters
        var source = Observable.Range(1, 5);
        // project the task parameters into the task execution, collect and flatten results
        source.SelectMany(i => DoubleAsync(i, random))
              // subscribe just for results, which turn up as they are done
              // gives you flexibility to continue the rx chain here
              .Subscribe(result => Console.WriteLine(result),
                        () => Console.WriteLine("All done."));
    }
