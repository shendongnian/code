    var dict = new Dictionary<string,string>(); 
    var input = str.Split(new [] { '=' },StringSplitOptions.RemoveEmptyEntries);
    for(int i=0; i<input.Length; i+=2)
    { 
        dict.Add(input[i], input[i+1]);
    }
