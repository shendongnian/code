    void Main()
    {   
        var line = @"/hello/1 /a/sdhdkd asjs /hello/2 ajhsd 
                   asjskjd sk /hello/s sajdk /hello/3 assdsfd hello/4";
        var searchString = "/hello/";
        var index = 0;
    
        var values = new List<int>();
    
        while(index < line.Length && 
             (index = line.IndexOf(searchString, index)) != -1)
        {
            index += searchString.Length;
            if(index < line.Length &&
    		   Char.IsDigit(line[index]))
                values.Add((int)(line[index] - '0'));
        }   
    
        Console.WriteLine(values);
    }
