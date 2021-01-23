    public static void PrintSentence(MyNode<string> root)
    {
        foreach(var node in root.TraverseLeafs())
        {
            Console.Write(node .Data + " ");
        }       
    }
