         Dictionary<string,string> dict =  new Dictionary<string,string>();
        dict.Add("element1key","element1value");
        dict.Add("element2key","element2value");
        dict.Add("element3key","element3value");
        string[] arry= new string[dict.Count];
        dict.Values.CopyTo(arry, 0);
        System.IO.File.WriteAllLines(@"C:\WriteLines.txt", arry);
