    using(IEnumerator<int> iterator = posNums.GetEnumerator())
        while(iterator.MoveNext())
        {
            int i = iterator.Current;
            Console.Write("" + i + " ");
        }
