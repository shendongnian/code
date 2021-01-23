    class Container {
      public int Value;
    }
    
    Container x = new Container();
    MyPrinter printer = new MyPrinter(x);
    printer.Print();
    x.Value++;
    MyPrint.Print();  // x.Value is 1 
