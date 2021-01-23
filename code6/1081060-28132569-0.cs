    public static void MyMethod<T>(Type theType) where T : ICat {}
    ICat icat = new Class2();
    //This will not work because its the wrong type
    IDog idog = new Class2();
    MyMethod<ICat>(icat.GetType());
