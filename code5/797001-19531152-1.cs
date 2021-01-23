    using System.Linq;
    using System.Collections.Generic;
    public T[][] ToMatrix<T>(T[] array, int elementsPerSubArray)
    {
        var list = new List<T[]>();
        while (array.Any())
        {
            list.Add(array.Take(elementsPerSubArray).ToArray());
            array = array.Skip(elementsPerSubArray).ToArray();
        }
        return list.ToArray();
    }
