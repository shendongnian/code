    private static DataContext context = null;
    public static MyDataContext GetContext()
    {
        if(context == null)
            context = new MyDataContext(ConnectionString);
        return context;
    }
