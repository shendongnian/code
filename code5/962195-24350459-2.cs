    IEnumerable<IList<T>> GetVariations<T>(IList<T> offers, int length)
    {
        var startIndices = new int[length];
        for (int i = 0; i < length; ++i)
            startIndices[i] = i;
        var indices = new HashSet<int>(); // for duplicate check
        while (startIndices[0] < offers.Count)
        {
            var variation = new List<T>(length);
            for (int i = 0; i < length; ++i)
            {
                variation.Add(offers[startIndices[i]]);
            }
            yield return variation;
            //Count up the indices
            AddOne(startIndices, length - 1, offers.Count - 1);
            //duplicate check                
            var check = true;
            while (check)
            {
                indices.Clear();                    
                for (int i = 0; i <= length; ++i)
                {
                    if (i == length)
                    {
                        check = false;
                        break;
                    }
                    if (indices.Contains(startIndices[i]))
                    {
                        var unchangedUpTo = AddOne(startIndices, i, offers.Count - 1);
                        indices.Clear();
                        for (int j = 0; j <= unchangedUpTo; ++j )
                        {
                            indices.Add(startIndices[j]);
                        }
                        int nextIndex = 0;
                        for(int j = unchangedUpTo + 1; j < length; ++j)
                        {
                            while (indices.Contains(nextIndex))
                                nextIndex++;
                            startIndices[j] = nextIndex++;
                        }
                        break;
                    }
                    indices.Add(startIndices[i]);
                }
            }
        }
    }
    int AddOne(int[] indices, int position, int maxElement)
    {
        //returns the index of the last element that has not been changed
        indices[position]++;
        for (int i = position; i > 0; --i)
        {
            if (indices[i] > maxElement)
            {
                indices[i] = 0;
                indices[i - 1]++;
            }
            else
                return i;
        }
        return 0;
    }
