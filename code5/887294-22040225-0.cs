    sentance.Find("jumped").Value = "over"
...
    static void Main(string[] args)
    {
        string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
        LinkedList<string> sentence = new LinkedList<string>(words);
        sentance.Find("jumped").Value = "over"
    
        foreach (string s in sentence)
        {
            Console.WriteLine(s);
        }
    
        Console.ReadLine();
    }
