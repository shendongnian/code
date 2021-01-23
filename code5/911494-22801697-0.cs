    System.Collections.Specialized.StringDictionary dotNetStringDict;
    System.Collections.IEnumerator dotNetEnumerator;
    System.Collections.DictionaryEntry dotNetDictEntry;
    str tempValue;
    ;
    
    dotNetStringDict = new System.Collections.Specialized.StringDictionary();
    dotNetStringDict.Add("Key_1", "Value_1");
    dotNetStringDict.Add("Key_2", "Value_2");
    dotNetStringDict.Add("Key_3", "Value_3");
    
    dotNetEnumerator = dotNetStringDict.GetEnumerator();
    while (dotNetEnumerator.MoveNext())
    {
        dotNetDictEntry = dotNetEnumerator.get_Current();
        tempValue = dotNetDictEntry.get_Value();
        info(tempValue);
    }
