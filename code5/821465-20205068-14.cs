    IEnumerator enumerator = ((IEnumerable)source).GetEnumerator();
    T variable; //declared here in C# 4 and older
    while(enumerator.MoveNext())
    {
        //T variable; //declared here in C# 5 and newer
        variable = (T)enumerator.Current; //Here is the run time error in your code.
       
        //The code inside the foreach loop.
        {
        }
    }
