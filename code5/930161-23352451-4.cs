    Regex finder = new Regex(":[012345][0123456789]:[012345][0123456789].*");
    Match m = finder.Match(Datain);
    if ( m.Success && m.Index > 1)
    {
        if ( char.IsDigit(DataIn[m.index-1]) && char.IsDigit(DataIn[m.index-2])
        {
            Dataout = DataIn.Substring(0, m.Index-2) + DataIn.Substring(m.Index + m.Length);
            // May need to protect the substrings against lengths of zero.
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
