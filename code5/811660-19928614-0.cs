    float[] values = 
            {
                0.01f,
                0.03f,
                0.10f,
                0.18f,
                0.24f,
                0.28f,
                0.30f,
                0.31f,
                0.33f,
                0.55f,
                2.34f,
                3.37f,
                9.19f,
                9.22f,
                10.28f
            };
            Dictionary<int, float[]> kvp = new Dictionary<int, float[]>();
            int j = 1;
            for (int i = 0; i < values.Length; i++)
            {
                if (i + 1 <= values.Length - 1)
                {
                    if (Math.Round(values[i + 1] - values[i], 2) == .02d)
                    {
                        kvp.Add(j, new float[] { values[i], values[i + 1] });
                        i++;                       
                    }
                    else
                        kvp.Add(j, new float[] { values[i] });
                }
                else               
                    kvp.Add(j, new float[] { values[i] });
                    j++;
            }
            foreach (var item in kvp)
            {             
                foreach (var i in item.Value)
                {
                    Console.WriteLine(item.Key + " " + i);
                }             
            }
