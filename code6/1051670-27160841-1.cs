    public int Aperture(int input)
    {
        var cs = Convert.ToString(input,2).ToCharArray().ToObservable();
    
        return cs.Publish(ps => ps.Where(c => c != '1')
                                  .Buffer(() => ps.Where(c => c == '1')))
                                  .Select(c => c.Count).Max().Wait();
    } 
