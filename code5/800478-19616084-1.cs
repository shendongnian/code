    var str = File.ReadAllText(@"c:\File1.txt");
                       var arr = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
      
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i].StartsWith("play"))
            {
                arr[i] = arr[i].Replace("play", "123");
            }
        }
       
        var res = string.Join(" ", arr);
    File.WriteAllText(@"c:\File1.txt", result);
