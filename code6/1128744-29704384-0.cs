    public void BubblesortBy<TSource, TKey>(Func<TSource, TKey> keySelector,
                                            List<TSource> stocks)
    {
        int loopCount = 0;
        bool doBreak = true;
    
        for (int i = 0; i < stocks.Count; i++)
        {
            doBreak = true;
            for (int j = 0; j < stocks.Count - 1; j++)
            {
                if (Compare(keySelector(stocks[j]), keySelector(stocks[j+1])))
                {
                    TSource temp = stocks[j + 1];
                    stocks[j + 1] = stocks[j];
                    stocks[j] = temp;
                    doBreak = false;
                }
                loopCount++;
            }
            if (doBreak) { break; /*early escape*/ }
        }
    }
    private bool Compare<T>(T l, T r)
    {
        return Comparer<T>.Default.Compare(l, r) > 0;
    }
