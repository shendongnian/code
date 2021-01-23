    Regex finder = new Regex(":[012345][0123456789]:[012345][0123456789].*");
    Match m = finder.Match(Datain);
    if ( m.Success && m.Index > 1)
    {
        if ( char.IsDigit(DataIn[m.index-1]) && char.IsDigit(DataIn[m.index-2])
        {
            Dataout = m.Index-2 == 0 ? string.Empty : DataIn.Substring(0, m.Index-2);
        }
        else
        {
            Dataout = Datain;
        }
    }
    else
    {
        Dataout = Datain;
    }
