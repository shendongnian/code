    public static List<List<T>> Pivot<T>(this List<List<T>> inputLists, bool removeEmpty, T defaultVal = default(T))
    {
        if (inputLists == null) throw new ArgumentNullException("inputLists");
        if(removeEmpty && !object.Equals(defaultVal, default(T))) throw new ArgumentException("You cannot provide a default value and removeEmpty at the same time!", "removeEmpty");
        
        int maxCount = inputLists.Max(l => l.Count);
        List<List<T>> outputLists = new List<List<T>>(maxCount);
        for(int i = 0; i < maxCount; i++)
        {
            List<T> list = new List<T>();
            outputLists.Add(list);
            for (int index = 0; index < inputLists.Count; index++)
            {
                List<T> inputList = inputLists[index];
                bool listSmaller = inputList.Count <= i;
                if (listSmaller)
                {
                    if (!removeEmpty)
                        list.Add(defaultVal);
                }
                else
                    list.Add(inputList[i]);
            }
        }
        return outputLists;
    }
