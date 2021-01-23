    private readonly List<double> _list = new List<double>(); 
    //created and initialized outside of your function
    public void CaylledByTimer()
    {
       _list.Add(RandomNumber(min, max));
       double totalSum = _list.Sum(); //you can use built-in LINQ Sum function
    }
