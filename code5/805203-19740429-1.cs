    List<int> Convert(List<string> stringList)
    {
        List<int> intList = new List<int>();  
        for (int i = 0; i < stringList.Count; i++) 
        {  
            intList.Add(int.Parse(stringList[i]));  
        }
        return intList;
    }
