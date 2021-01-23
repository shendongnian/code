    //initial values
    Console.WriteLine(first); //A0
    Console.WriteLine(second); //A1
    int outputs = 4000000;
    for( int n = 0; n < outputs; n++ )
    {
     //adjust
     int result = first + second;
     first = second;
     second = result;
     //output
     Console.WriteLine(result); //An
    }
