    Container myContainer = new Container();
    myContainer.x = 0;
    MyPrinter printer = new MyPrinter(myContainer); // Passes the reference to the same instance
    printer.Print(); //Result is 0 - because it uses the variable attached to the instance
    myContainer.x ++; // Increments the variable attached to the instance
    MyPrinter.Print(); //Result is 1 - because the instance is still the same in both places - due to being passed by reference.
