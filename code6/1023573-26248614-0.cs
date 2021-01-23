    enum ReadState
    {
        Start,
        SawOpen
    }
    
    var rs = ReadState.Start;
    using (var sr = new StreamReader(@"path\to\clinic.txt"))
    using (var sw = new StreamWriter(@"path\to\output.txt"))
    {
        while (true)
        {
            var r = sr.Read();
            if (r < 0)
                break;
            char c = (char) r;
            if ((c == '\r') || (c == '\n'))
                continue;
            if (c == '<')
            {
                rs = ReadState.SawOpen;
                continue;
            }
            if (rs == ReadState.SawOpen)
            {
                if (c == 'C')
                    sw.WriteLine();
                sw.Write('<');
            }
            sw.Write(c);
            rs = ReadState.Start;
        }
    }
