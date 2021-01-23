    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace test
    {
        static class IntArray
        {
            public static int[] FromValues(params int[] values)
            {
                return values;
            }
            public static int[] Sequence(int from, int length)
            {
                if (from < 0 || length < 1)
                    throw new ArgumentException();
                return Enumerable.Range(from, length).ToArray();
            }
            public static int[][] Combinations(int[] list1, int[] list2)
            {
                return Combinations(list1.Select(i => new int[] { i }).ToArray(), list2);
            }
            public static int[][] Combinations(int[][] list1, int[] list2)
            {
                List<List<int>> result = new List<List<int>>();
                for (int i = 0; i < list1.Length; i++)
                {
                    for (int j = 0; j < list2.Length; j++)
                        result.Add(((int[]) list1.GetValue(i)).Concat(new int[] { list2[j] }).ToList());
                }
                return result.Select(i => i.ToArray()).ToArray();
            }
        }
        abstract class BoundedArray<T>
        {
            public BoundedArray()
            {
                m_data = null;
            }
            public Array Value
            {
                get { return m_data; }
            }
            public T this[params int[] index]
            {
                get
                {
                    if (index.Length != m_data.Rank)
                        throw new IndexOutOfRangeException();
                    return (T) m_data.GetValue(index);
                }
                set
                {
                    if (index.Length != m_data.Rank)
                        throw new IndexOutOfRangeException();
                    m_data.SetValue(value, index);
                }
            }
            protected void SetAttributes(params int[][] values)
            {
                // Make sure all of the values are pairs
                if (values.Where(i => i.Length != 2).ToArray().Length > 0)
                    throw new ArgumentException("Input arrays must be of length 2.");
                int[] lowerBounds = values.Select(i => i[0]).ToArray();
                int[] lengths = values.Select(i => i[1] - i[0] + 1).ToArray();
                m_data = Array.CreateInstance(typeof(T), lengths, lowerBounds);
                int[][] indices = (lowerBounds.Length != 1) ?
                    IntArray.Combinations(IntArray.Sequence(lowerBounds[0], lengths[0]), IntArray.Sequence(lowerBounds[1], lengths[1]))
                    : IntArray.Sequence(lowerBounds[0], lengths[0]).Select(i => new int[] { i }).ToArray();
                for (int i = 2; i < lowerBounds.Length; i++)
                    indices = IntArray.Combinations(indices, IntArray.Sequence(lowerBounds[i], lengths[i]));
                for (int i = 0; i < indices.Length; i++)
                    m_data.SetValue(Activator.CreateInstance(typeof(T)), indices[i]);
            }
            Array m_data;
        }
    }
