    private IObservable<string> GetCompleteMessage(IObservable<byte[]> bytes)
    {
        const byte byteLineFeed = 10;
        return bytes.Scan(
            new
            {
                Leftovers = (byte[])null,
                Line = (string)null
            },
            (tuple, current) =>
            {
                var lastPositionOfLineFeed = -1;
                var newLeftovers = tuple.Leftovers;
                var line = (string)null;
                for (var i = 0; i < current.Length; i++)
                {
                    if (current[i] == byteLineFeed)
                    {
                        if (tuple.Leftovers != null)
                        {
                            line = Encoding.ASCII.GetString(
                                        tuple.Leftovers.Union(current.Slice(lastPositionOfLineFeed + 1,
                                            i - lastPositionOfLineFeed))
                                                    .ToArray());
                            newLeftovers = null;
                        }
                        else
                        {
                            line = Encoding.ASCII.GetString(
                                    current.Slice(lastPositionOfLineFeed + 1,
                                        i - lastPositionOfLineFeed));
                        }
                        lastPositionOfLineFeed = i;
                    }
                }
                if (lastPositionOfLineFeed != current.Length - 1)
                {
                    if (tuple.Leftovers != null)
                    {
                        newLeftovers = tuple.Leftovers.Union(current.Slice(lastPositionOfLineFeed + 1,
                                current.Length - lastPositionOfLineFeed - 1))
                                                    .ToArray();
                    }
                    else
                    {
                        newLeftovers = current.Slice(lastPositionOfLineFeed + 1,
                            current.Length - lastPositionOfLineFeed - 1);
                    }
                }
                return new
                {
                    Leftovers = newLeftovers,
                    Line = line,
                };
            })
            .Select(tuple => tuple.Line)
            .Where(line => line != null);
    }
