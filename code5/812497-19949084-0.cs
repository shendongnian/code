    for(int i = 0; i < caseNumberList.Length; i+=10) {
        foreach (string commaString in ProcessGroup(caseNumberList, i, 10))
        {
            Console.Write(commaString);
            Console.Write(",");
        }
            
        Console.Write("\r\n");
    }
    static IEnumerable ProcessGroup(int[] number, int startindex, int limit)
    {
        int itemNum = startindex;
        int iterations = 0;
        string caseNumbers = string.Empty;
        //
        // Continue loop until the exponent count is reached.
        //
        while (iterations < limit)
        {
            caseNumbers = caseNumbers + number[itemNum];
            itemNum++;
            iterations++;
            yield return caseNumbers;
        }
    } 
