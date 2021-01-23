    float[] initialArray = { 2.0f, 6.5f, 2.0f };
    List<float> initialArrayTemp = ToList<float>(initialArray);
    private List<float> ToList<T1>(float[] array)
            {
                List<float> list = new List<float>();
                for (int i = 0; i < array.Length; i++)
                {
                    list.Add(array[i]);
                }
                return list;
            }
