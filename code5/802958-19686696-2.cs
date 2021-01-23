    foreach (var item in inputs)
    {
        var lastPos = 
            item.IndexOf('/', 
                1 + item.IndexOf('/', 
                    1 + item.IndexOf('/')));
        if (lastPos != -1)
        {
            var r = String.Join("\t", 
                item.Substring(0, lastPos), 
                item.Substring(lastPos + 1, item.Length - lastPos - 1));
            Console.WriteLine(r);
        }
    }
