    // Pattern: Any instance of [] with one or more characters of between them:
    var pattern = @"\[.+\]"; 
    while((line = file.ReadLine()) != null)
    {
        if(!Regex.IsMatch(line, pattern)) // Skip lines that match
        {
            Console.WriteLine(line);
        }      
    }
