    public class populate
    {
        public populate (string string1 ,string string2)
        {
            char[] result = string2.ToCharArray();
            for (int i=1; i < string1.Length; i++)
            {
                if (string1[i] == string1[i-1])
                {
                    result[i] = string1[i];
                    Console.WriteLine ("Character Copied");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            string2 = new string(result);
            Console.WriteLine (string2);
        }
