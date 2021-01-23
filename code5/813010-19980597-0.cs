    public static IEnumerable<Tuple<int, T>> SplitItems<T>(IEnumerable<T> items, int count)
    {
        var itemList = items.ToList();
        int wholeRowItemCount = (itemList.Count / count) * count;
        int lastRowCount = itemList.Count % count;
        // return full rows: 0 <= i < wholeRowCount * count
        for (int i = 0; i < wholeRowItemCount; i++)
        {
            yield return Tuple.Create(i % count, itemList[i]);
        }
        if (lastRowCount > 0)
        {
            //return final row: wholeRowCount * count <= i < itemList.Count
            double offset = (double)count / (lastRowCount + 1);
            for (double j = 0; j < lastRowCount; j++)
            {
                int thisIntPos = (int)Math.Round(j * count / (lastRowCount + 1) + offset, MidpointRounding.AwayFromZero);
                yield return Tuple.Create(thisIntPos, itemList[wholeRowItemCount + (int)j]);
            }
        }
    }
