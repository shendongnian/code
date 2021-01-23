        List<string> lines = new List<string>();
        while (!myStream.EndOfStream)
        {
           lines.Add(myStream.ReadLine());
        }
        return lines.ToArray();
