    public Something GetSomething(){
        Something s = Cache.Get("some key");
        if(s!=null)return s;
        var con = new SqlConnection(...);
        ...;
        return s;
    }
