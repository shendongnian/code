    string s = "";
    for (int i = 0; i < ListOfGenericClasses.Count; i++)
    {
        s += ListOfGenericClasses[i].GetType()
                           .GetMethod("doSomething")
                           .Invoke(ListOfGenericClasses[i], null);
    }
