    int x = 0;
    MyPrinter printer = new MyPrinter(x); // Makes a copy of x, and passes the copy to MyPrinter
    printer.Print(); //Expected result is 0 - correct
    x++; // Increments the local variable, but not the copy
    MyPrinter.Print(); //Expected result is 1 - incorrect because only the local variable is updated.
