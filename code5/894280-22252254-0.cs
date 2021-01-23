    //Initialization
    Dictionary<string, string> previousLines = new Dictionary<string, string>();
    TextReader tw = new TextReader(filePath);
    string line = String.Empty;
    
    //Read the file one line at a time
    while((line = tw.ReadLine()) != null)
    {
        if(line.contains("ITRS")
        {
            //Get the number you will use for searching
            string number = line.split(new char[]{' '})[4];
            //Use the dictionary to read a line you have previously read.
            string line = previousLines[number];
            
            previousLines.Clear(); //Remove the elements so that they do not interrupt the next searches. I am assuming that you want to search between lines which are found between ITRS tags. If you do not want this, simply omit this line.
            ... //Do your logic here.
        }
        else 
        {
             string number = line.split(new char[]{' '})[4];
             previousLines.Add(number, line);
        }
    }
