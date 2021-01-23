    public static IEnumerable<IList> Permutate(IList sequence, int count)
    {
        if (count == 1) yield return sequence;
        else
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var perm in Permutate(sequence, count - 1))
                    yield return perm;
                RotateRight(sequence, count);
            }
        }
    }
