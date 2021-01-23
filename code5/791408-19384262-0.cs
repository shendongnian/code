    Assembly Lib:
       Interface A;
       Interface B; //Utilizes multiple properties with a { get; } pattern.
       //Contains more interface definitions like Interface B
    Assembly Impl: //References Lib 
        Class 123; //Utilizes multiple properties with a { get; internal set; } 
                   //pattern. Implements B.
        //Contains more class definitions like Class 123
        Class MyImpl; //Implements Interface A and utilizes Class 123.
    ClientApplication:
        //Consumes implementations of Interface A and B provided by Impl.
