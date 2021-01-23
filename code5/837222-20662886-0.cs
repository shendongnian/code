    AsmHelper asmHelper = new AsmHelper(CSScript.Compile(filePath), null, false);
    object obj = asmHelper.CreateObject("*");
    IMyInterface instance = asmHelper.TryAlignToInterface<IMyInterface>(obj);
    // Any other interfaces you want to instantiate...
    ...
    if (instance != null)
        instance.MyScriptMethod();
