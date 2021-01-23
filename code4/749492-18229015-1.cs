    Variables v=new Variables();
    v.AdId=2;
    for(int i=0; i<a.count() ;i++)
    {
    switch (a.count())
        { 
            case 0:
                v.Variable1 = a[i].ToString();
                break;
            case 1:
                v.Variable1 = a[i].ToString();
                v.Variable2 = a[i++].ToString();
             case 2:
                v.Variable1 = a[i].ToString();
                v.Variable2 = a[i++].ToString();
                v.Variable2 = a[i+2].ToString();
                break;
    and so on.....
        }
    }
