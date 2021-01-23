    private static void ReproTreeEnquiry(REngine e)
    {
       e.Evaluate("library(tree)");
       var irtr = e.Evaluate("ir.tr <- tree(Species ~., iris)");
       // the following will print a human readable tree to the console output
       e.Evaluate("print(ir.tr)");
       var aList = irtr.AsList(); // May work only with the latest dev code
       // for R.NET 1.5.5 you may need to do instead:
       aList = e.Evaluate("as.list(tree(Species ~., iris))").AsList();
       var theDataFrame = aList[0].AsDataFrame();
       // Further processing of theDataFrame, etc.
    }
