    List<string> list = new List<string>();
    list.Add("Apple");
    list.Add("Bubble");
    list.Add("Dino");
    list.Add("Common");
    list.Add("Aalborg");
            
    list.Sort(new CultureInfo("da-DK").CompareInfo.Compare);
    Console.WriteLine(string.Join(",",list)); //As in question
    list.Sort(new CultureInfo("en-US").CompareInfo.Compare);
    Console.WriteLine(string.Join(",",list)); //As people expect
