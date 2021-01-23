    Parallel.For(0, _documentVectorSpace.Count, i =>
    {
        int count = 0;
        double[] vec = new double[_distinctTerms.Count];
        Parallel.ForEach(_documentVectorSpace[i].Terms, term =>
        {
            if (_distinctTerms.ContainsKey(term))
            {
                Interlocked.Increment(ref vec[_distinctTerms[term]]);
            }
        });
        _documentVectorSpace[i].VectorSpace = vec;
     });
