    int isInteger;
    Console.WriteLine("Input Characters: ");
    string x = Console.ReadLine();
    if(int.TryParse(x, out isInteger)
      Console.WriteLine("int");
    else
      Console.WriteLine("not int"); 
