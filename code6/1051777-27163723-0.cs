    static void DisplayScore(string[] names, int[] scores)
    {
       for(int i=0; i < names.Length; i++)
       {
           Console.WriteLine("{0}'s score was {1}.\n", names[i], scores[i]);
       }
    }
    // etc
