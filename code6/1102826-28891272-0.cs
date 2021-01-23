       foreach (var second in Enumerable.Range((int)beginningDate.FirstOrDefault(),
                                                (int)endDate.Last() - (int)beginningDate.FirstOrDefault()))
                {
                    var callsCount = 0;
                    for (var i = 0; i < beginningDate.Last(); ++i)
                    {
                        if (beginningDate[i] <= second && second <= endDate[i])
                        {
                            ++callsCount;
                        }
                    }
                    if (callsCount > maxCallsCount)
                    {
                        maxCallsCount = callsCount;
                    }
                }
