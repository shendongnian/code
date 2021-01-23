    IEnumerable<ComplexObject> EnumerateObjects(IEnumerable<int> ids)
    {
        foreach (var id in ids)
        {
            using (var obj = CreateSingleComplexObject(id))
            {
                yield return obj;
            }
        }
    }
