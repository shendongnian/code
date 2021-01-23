    static int[][] makearrays(string filename)
    {
        List<List<int>> outval = new List<List<int>>();
        using(StreamReader sr = new StreamReader(filename))
        {
            while(!sr.EndOfStream)
            {
                int a = 0, b = 0;
                a = int.Parse(sr.ReadLine());
                if(!sr.EndOfStream)
                    b = int.Parse(sr.ReadLine());
                else
                {
                    outval.Add(new List<int>() { a });
                    break;
                }
                if(a > b)
                    outval.Add(new List<int>() { b, a });
                else
                    outval.Add(new List<int>() { a, b });
            }
        }
        return outval.Select(x => x.ToArray()).ToArray();
    }
