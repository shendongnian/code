        var x = new List<string>{"A","B","C","D","E","F"};
        var result = new Dictionary<int, List<string>>();
        var sequence = 1;
        for (var i = 0; i*2 < x.Length ; i++)
        {
            groupList = new List<string>();
            groupList.Add(x[i*2]);
            if(i*2+1 < x.Length)
            {
                groupList.Add(x[i*2+1]);
            }
            result.Add(sequence, groupList);
                sequence++;
        }
        return result;
