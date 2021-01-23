    static void Main(string[] args)
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        int max = Math.Max(a.Length, b.Length);
        int min = Math.Min(a.Length, b.Length);
        // dividing integer by integer will return integer
        // therefore durign division you need to indicate need for floating point value
        // or just use float type, cheap trick, but it works just as well and makes code cleaner
        float c = 0;
        // for each character up to end of shorter string
        for (int i=0; i<min; i++)
        {
            // compare them
            if (a[i] == b[i])
            {
                // and if equal, increase counter
                c++;
            }
        }
        Console.WriteLine("Similarity is {0:P}", c / max);
        Console.ReadLine();
    }
