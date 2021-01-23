    IEnumerator enumerator = ((IEnumerable)source).GetEnumerator();
    T variable; //foo declared here in .net 4.0 and older
    while(enumerator.MoveNext())
    {
        //T variable; //foo declared here in .net 4.5 and newer
        variable = (T)enumerator.Current; //Here is the run time error.
       
        //The code inside the foreach loop.
        {
        }
    }
