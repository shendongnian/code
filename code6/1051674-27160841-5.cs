    public int Aperture(int input)
    {    
        var cs = Convert.ToString(input,2).ToCharArray().ToObservable();
        
        return cs.Scan(
            Tuple.Create(0,0), (acc, c) => c == '0'
                ? Tuple.Create(acc.Item1 + 1, acc.Item2)
                : Tuple.Create(0, acc.Item1)
            ).Select(x => x.Item2).Max().Wait();
    }
