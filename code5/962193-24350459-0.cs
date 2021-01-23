    IEnumerable<IList<T>> GetVariations<T>(IList<T> offers, int length)
    {
        var startIndices = new int[length];
        var variationElements = new HashSet<T>(); //for duplicate detection
        while (startIndices[0] < offers.Count)
        {                
            var variation = new List<T>(length);
            var valid = true;
            for (int i = 0; i < length; ++i)
            {
                var element = offers[startIndices[i]];
                if (variationElements.Contains(element))
                {
                    valid = false;
                    break;
                }
                variation.Add(element);
                variationElements.Add(element);
            }
            if (valid)
                yield return variation;
            //Count up the indices
            startIndices[length - 1]++;
            for (int i = length - 1; i > 0; --i)
            {
                if (startIndices[i] >= offers.Count)
                {
                    startIndices[i] = 0;
                    startIndices[i - 1]++;
                }
                else
                    break;
            }
            variationElements.Clear();
        }
    }
