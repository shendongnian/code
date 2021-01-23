    public static object Sum(params object[] inputs)
            {
                var sum = inputs[0];
                for (int i = 1; i < inputs.Length; i++)
                {
                    sum = Add(sum,inputs[i]);
                }
    
                return sum;
            }
