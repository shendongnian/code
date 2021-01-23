    object[,] ToMultiObject<T>(this IList<IList<T>> source)
    {
        var x = source.Max(r => r.Count);
        var y = source.Count;
        var result = new object[x, y];
        for (var i = 0, i < source.Count, i++)
        {
            for (var j = 0, j < source[i].Count, j++)
            {
                result[j, i] = source[i][j];
            }
        }
        return result;
    }
