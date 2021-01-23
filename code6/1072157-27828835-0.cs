    public void method1()
    {       
            int trycount = 0;     
            ....
            foreach (var gtin in gtins)
            {
                method2(gtin, ref trycount);
            }           
        if (trycount > 5)
        {...}
    }
    public void method2 (string gtin, ref int trycount)
    {
        ......  
        trycount++; // this will modify the variable declared earlier
    }
