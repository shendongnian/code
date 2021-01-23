    long[] results = new long[] { 15, 14, 16 };
    try
    {
        Array.Sort(results);
        Array.ForEach(results, (v) => {
            switch (v)
            {
                case 14:
                    throw GetOutException();
                case 15:
                    throw GetOutException();
                case 16:
                    throw GetOutException();
            }
        });
    }
    catch { }
