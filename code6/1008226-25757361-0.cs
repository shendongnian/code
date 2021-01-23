     public static void ChangeSalaries(List<double> incomez, int percent)
        {
            for (int i = 0; i < incomez.Count; ++i)
            {
              
              incomez[i] = ((incomez[i] * percent) / 100) + incomez[i];
              Console.WriteLine(incomez[i]);
            }
        }
