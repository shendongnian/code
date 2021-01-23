    // timestamp data and "record" or "display" it.
    output.Timestamp()
        .Subscribe(x => {
            if(x.Value.Item1)
                Console.WriteLine(x.Timestamp + ": Recording " + x.Value.Item2);
            else
                Console.WriteLine(x.Timestamp + ": Displaying " + x.Value.Item2);
        },
        () => Console.WriteLine("Stopped")); 
