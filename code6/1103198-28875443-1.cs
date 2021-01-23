    float[] initialArray = { 2.0f, 6.5f, 2.0f };
    List<float> initialArrayTemp = ToListFloat(initialArray);
    private List<float> ToListFloat(float[] array)
            {
                List<float> list = new List<float>();
                for (int i = 0; i < array.Length; i++)
                {
                    list.Add(array[i]);
                }
                return list;
            }
