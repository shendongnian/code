    //Following are the possibilities
    //This can be done in some other class and passed to some other method
    //maybe a factory pattern
    MyAbClass cls1 = new MyConcretClass1();
    //Will call method of MyConcretClass1
    cls1.MyM1();
    if (cls1 is MyConcretClass1)
    { 
        //Do casting here
    }
    var cls2 = cls1 as MyConcretClass1;
    if (cls2 != null)
    { 
        //Do your stuff here
    }
    //This can be done in some other class and passed to some other method
    //maybe a factory pattern
    IMyInterface cls3 = new MyConcretClass2();
    //Will call method of MyConcretClass2
    cls3.MyM2();
    if (cls3 is MyConcretClass2)
    {
        //Do casting here
    }
    var cls4 = cls3 as MyConcretClass1;
    if (cls4 != null)
    {
        //Do your stuff here
    }
