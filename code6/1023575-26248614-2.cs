    enum ReadState
    {
        Start,
        SawOpen
    }
    
    using (var sr = new StreamReader(@"path\to\clinic.txt"))
    using (var sw = new StreamWriter(@"path\to\output.txt"))
    {
        var rs = ReadState.Start;
        while (true)
        {
            var r = sr.Read();
            if (r < 0)
                break;
            char c = (char) r;
            if ((c == '\r') || (c == '\n'))
                continue;
            if (rs == ReadState.SawOpen)
            {
                if (c == 'C')
                    sw.WriteLine();
    
                sw.Write('<');
                rs = ReadState.Start;
            }
            if (c == '<')
            {
                rs = ReadState.SawOpen;
                continue;
            }
            sw.Write(c);
        }
    }
