    public int Aperture(int input)
    {
        var cs = Convert.ToString(input,2).ToCharArray().ToObservable();     
        
        return cs.Publish(ps => ps.Buffer(() => ps.Where(c => c == '1')))
        .Where(x => x.LastOrDefault() == '1')
        .Select(x => x.Count - 1)
        .Max().Wait();
    }
    Aperture(9)   = 2
    Aperture(529) = 4
    Aperture(20)  = 1
    Aperture(15)  = 0
