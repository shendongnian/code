    private List<List<T>> MyList;
    
    public T this[int a, int b]
    {
        get { return MyList[a][b]; }
        set { MyList[a][b] = value; }
    }
