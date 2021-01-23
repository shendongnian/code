    List<string> messages = new List<string>();
    messages.Add("a"); 
    messages.Add("b");
    messages.Add("c");
    for (int i = 0; i < messages.Count; i++)
    {
         messages.RemoveAt(0);
    }
