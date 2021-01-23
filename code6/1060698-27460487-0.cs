    public static void CopyTo1(int[] array1, int[] array2, int startat)
        {
            for (int i = 0; i < array1.Length; i++)
            {
               array2[startat] = array1[i];
                startat++;
               Console.Write(array2[i].ToString());
            }
        }
