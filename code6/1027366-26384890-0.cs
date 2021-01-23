    var block = new TransfromBlock<string, int>(number =>
    {
        try
        {
            return int.Parse(number);
        }
        catch (Exception e)
        {
            Trace.WriteLine(e);
        }
    });
