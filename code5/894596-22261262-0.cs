    public class Container
    {
        public int x;
    }
    ... // some implementation in another class
    Container myContainer = new Container();
    myContainer.x = 0;
    MyPrinter printer = new MyPrinter(myContainer);
    printer.Print(); //Result is 0
    myContainer.x ++;
    MyPrinter.Print(); //Result is 1
