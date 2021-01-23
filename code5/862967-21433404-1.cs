    //Processint first file
    List<DataTimeContainer> Container1 = new List<DataTimeContainer>();
    string[] lines = File.ReadAllLines("c:\\data1.csv");
    string groupTimeValue1 = string.Empty;
    string groupTimeValue2 = string.Empty;
    foreach (string[] fields in lines.Select(l => l.Split(';')))
    {
        //iterating over every line, splited by ';' delimiter
        if (!string.IsNullOrWhiteSpace(fields[0]))
        {
            //we're in a line having both values, like:
            //06:07:00 ; 6:07
            groupTimeValue1 = fields[0];
            groupTimeValue2 = fields[1];
        }
        else
            //we're in line looking like this:
            //            ; DataX
            Container1.Add(new DataTimeContainer(){Data = fields[1], TimeValue1 = groupTimeValue1, TimeValue2 = groupTimeValue2});
    }
    //Processing second file
    List<DataTimeContainer> Container2 = new List<DataTimeContainer>();
    lines = File.ReadAllLines("c:\\data2.txt");
    foreach (string[] fields in lines.Select(l => l.Split(';')))
    {
        Container2.Add(new DataTimeContainer() { TimeValue1 = fields[1], TimeValue2 = fields[2], Data = fields[3]});
    }
    DoSomeComparison();
