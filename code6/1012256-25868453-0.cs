    string s = "";
    for (int i = 0; i < ListOfGenericClasses.Count; i++)
    {
        Type type = ListOfGenericClasses[i].GetType();          
        dynamic d = Convert.ChangeType(ListOfGenericClasses[i], type);
        s += d.doSomething() + " # ";               
    }
