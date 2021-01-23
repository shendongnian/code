    using util = MyNameSpace.MyVeryLongNameStaticUtilityClass;
    using other = MyNameSpace.MyVeryLongNameOtherClass;
    
    private static void Main(string[] args)
    {
        var result = util.ParseArgs(args);
        var other = new other();
    }
