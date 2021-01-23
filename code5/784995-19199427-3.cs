    var outInt = 0;
    var result = lst.OrderByDescending(p =>
                {
                    if (Int32.TryParse(p[1], out outInt))
                    {
                        return outInt;
                    }
                    else
                    {
                        return -1;
                    }
                }).Take(5);
