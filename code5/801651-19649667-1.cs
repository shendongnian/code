    void Main()
    {
        string input = @"1 TESTAAA      SERNUM    A DESCRIPTION
    2 TESTBBB      ANOTHR    ANOTHER DESCRIPTION
    3 TESTXXX      BLAHBL";
    
        var split = input.Split('\n').Select(s => new {
            Id = s.Substring(0, 2),
            FirstText = s.Substring(2, 13),
            Serial = s.Substring(15, Math.Min(s.Length-15, 10)),
            Description = s.Length > 25 ? s.Substring(25) : String.Empty
        });
        
        split.Dump();
    }
    /* Output */
    Id FirstText     Serial     Description 
    1  TESTAAA       SERNUM     A DESCRIPTION
     
    2  TESTBBB       ANOTHR     ANOTHER DESCRIPTION
     
    3  TESTXXX       BLAHBL   
