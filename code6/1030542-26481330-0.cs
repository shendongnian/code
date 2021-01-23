    ....
    Int64[,] whau = new Int64[X,Y]; // I don't know the size of this.
    ....
    [WebMethod]
    static setList(Int64[,] list_web)
    {
        whau = list_web;
    }
    public void func1 ()
    {
        Int64[,] list = Int64[1, 2];
        list[0, 1] = 1;
        list[0, 2] = 2;
        service.setList(list);
    }
